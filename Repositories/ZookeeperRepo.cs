using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 
using System.Security.Cryptography;

namespace ZooManagement.Repositories
{
    public interface IZookeeperRepo
    {
        Zookeeper CreateZookeeper(CreateZookeeperRequest zookeeper);

        ZookeeperResponse GetZookeeper(int id);
        // Animal GetAnimalbyId(int id);
        // // Animal Create(CreateAnimalRequest newAnimal);
        // List<Animal> Search(AnimalSearchRequest searchRequest);
   
    }

    public class ZookeeperRepo : IZookeeperRepo
    {
        private readonly ZooManagementDbContext _context;

        public ZookeeperRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        public Zookeeper CreateZookeeper(CreateZookeeperRequest zookeeper)
        {
            List<Enclosure> encList = new List<Enclosure>();
                
            foreach (var item in zookeeper.EnclosureIds)
                {
                   encList.Add(_context.Enclosure
                            .Single(e => e.Id == item)); 
                }
            var insertResponse = _context.Zookeeper.Add(new Zookeeper
            {
                ZookeeperName = zookeeper.ZookeeperName,
                ZookeeperSex = zookeeper.ZookeeperSex,
                Enclosures = encList,
            });
            _context.SaveChanges();
            return insertResponse.Entity;

        }

        public ZookeeperResponse GetZookeeper(int id)
        {
            ZookeeperResponse zookeeperRes = new ZookeeperResponse(); 
            var  zookeeper =  _context.Zookeeper
                .Include(e => e.Enclosures)
                .Include(a => a.Animals)
                .SingleOrDefault(z => z.Id == id);

                zookeeperRes.Id=zookeeper.Id;
                zookeeperRes.ZookeeperName = zookeeper.ZookeeperName;
                zookeeperRes.ZookeeperSex = zookeeper.ZookeeperSex;
                zookeeperRes.Enclosures = zookeeper.Enclosures.ToList();
                zookeeperRes.Animals = zookeeper.Animals.ToList();

            return zookeeperRes;
        }

        // public List<Animal> Search(AnimalSearchRequest search)
        // {
        //     // return _context.Animal
        //     //     .Include(c => c.AnimalType)
        //     //     .Where(p => search.Filters== null ||
        //     //                 (
        //     //                     p.AnimalName.ToLower().Contains(search.AnimalName) ||
        //     //                     p.AnimalType.Species.ToLower().Contains(search.Species) ||
        //     //                     p.AnimalType.AnimalClass.ToLower().Contains(search.AnimalClass) ||
        //     //                     p.AnimalType.TypeName.ToLower().Contains(search.TypeName)
        //     //                 ))
        //     //     .OrderBy(u => u.AnimalType.Species)
        //     //     .Skip((search.Page - 1) * search.PageSize)
        //     //     .Take(search.PageSize);

        //     var animal = _context.Animal
        //         .Include(c => c.AnimalType)
        //         .Include(a => a.Enclosure)
        //         .AsQueryable();
        //     if (!String.IsNullOrEmpty(search.AnimalName)){
        //         animal = animal.Where(s => s.AnimalName.ToLower().Contains(search.AnimalName.ToLower()));
        //     }
        //     if (!String.IsNullOrEmpty(search.Species)){
        //         animal = animal.Where(s => s.AnimalType.Species.ToLower().Contains(search.Species.ToLower()));
        //     }
        //     if (!String.IsNullOrEmpty(search.AnimalClass)){
        //         animal = animal.Where(s => s.AnimalType.AnimalClass.ToLower().Contains(search.AnimalClass.ToLower()));
        //     }
        //     if (!String.IsNullOrEmpty(search.TypeName)){
        //         animal = animal.Where(s => s.AnimalType.TypeName.ToLower().Contains(search.TypeName.ToLower()));
        //     }
        //     if (search.AquisitionDate.HasValue){
        //         animal = animal.Where(s => s.AquisitionDate == search.AquisitionDate);
        //     }
        //     if (search.Age.HasValue){
        //         int num = -1 * search.Age ?? default(int);
        //         animal = animal.Where(s => s.DOB < (DateTime.Now.AddYears(num)));
        //     }
        //     if (search.Age.HasValue){
        //         int num = -1 * search.Age ?? default(int);
        //         animal = animal.Where(s => s.DOB > (DateTime.Now.AddYears(num-1)));
        //     }

        //     if (!String.IsNullOrEmpty(search.EnclosureName)){
        //         animal = animal.Where(s => s.Enclosure.EnclosureName.ToLower().Contains(search.EnclosureName.ToLower()));
        //     }

        //     if(search.Enclosure_Id.HasValue){
        //         animal = animal.Where(s => s.Enclosure_Id == (search.Enclosure_Id));
        //     }
        //     if (String.IsNullOrEmpty(search.Order))
        //     {
        //         search.Order = "";
        //     }
        //     switch(search.Order.ToLower())    
        //     {
        //     default:
        //         animal = animal.OrderBy(u => u.AnimalType.Species).AsQueryable();
        //         break;
        //     case "animalname":
        //         animal = animal.OrderBy(u => u.AnimalName.AsQueryable() );
        //         break;
        //     case "animalclass":
        //         animal = animal.OrderBy(u => u.AnimalType.AnimalClass.AsQueryable() );
        //         break;
        //     case "typename":
        //         animal = animal.OrderBy(u => u.AnimalType.TypeName.AsQueryable() );
        //         break;
        //     case "enclosure":
        //         // animal= animal.OrderBy(u=> u.Enclosure_Id);
        //         // animal = animal.OrderBy(a => a.AnimalName.AsQueryable());
        //                     //   .ThenBy(a => a.AnimalName.AsQueryable());
        //         animal= animal.OrderBy(u=> u.Enclosure_Id).ThenBy(a => a.AnimalName.AsQueryable());
        //         break;
        //     }
        //     var animalReturn = animal.Skip((search.Page - 1) * search.PageSize)
        //     .Take(search.PageSize)
        //     .ToList();
        //     return animalReturn;
        // }
 
    }
} 
