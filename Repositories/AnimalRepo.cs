using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 
using System.Security.Cryptography;

namespace ZooManagement.Repositories
{
    public interface IAnimalRepo
    {
        Animal CreateAnimal(CreateAnimalRequest animal );
        Animal GetAnimalbyId(int id);
        // Animal Create(CreateAnimalRequest newAnimal);
        List<Animal> Search(AnimalSearchRequest searchRequest);
   
    }

    public class AnimalRepo : IAnimalRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        public Animal CreateAnimal(CreateAnimalRequest animal)
        {
             var insertResponse = _context.Animal.Add(new Animal
            {
                AnimalType_Id = animal.AnimalType_Id,
                AnimalName = animal.AnimalName,
                Sex = animal.Sex,
                AquisitionDate = animal.AquisitionDate,
                DOB = animal.DOB,
            });
            _context.SaveChanges();
            return insertResponse.Entity;
        }

        public Animal GetAnimalbyId(int id)
        {
            return _context.Animal
                .SingleOrDefault(animal => animal.Id == id);
        }

        public List<Animal> Search(AnimalSearchRequest search)
        {
            // return _context.Animal
            //     .Include(c => c.AnimalType)
            //     .Where(p => search.Filters== null ||
            //                 (
            //                     p.AnimalName.ToLower().Contains(search.AnimalName) ||
            //                     p.AnimalType.Species.ToLower().Contains(search.Species) ||
            //                     p.AnimalType.AnimalClass.ToLower().Contains(search.AnimalClass) ||
            //                     p.AnimalType.TypeName.ToLower().Contains(search.TypeName)
            //                 ))
            //     .OrderBy(u => u.AnimalType.Species)
            //     .Skip((search.Page - 1) * search.PageSize)
            //     .Take(search.PageSize);

            var animal = _context.Animal
                .Include(c => c.AnimalType)
                .AsQueryable();
            if (!String.IsNullOrEmpty(search.AnimalName)){
                animal = animal.Where(s => s.AnimalName.ToLower().Contains(search.AnimalName.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.Species)){
                animal = animal.Where(s => s.AnimalType.Species.ToLower().Contains(search.Species.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.AnimalClass)){
                animal = animal.Where(s => s.AnimalType.AnimalClass.ToLower().Contains(search.AnimalClass.ToLower()));
            }
            if (!String.IsNullOrEmpty(search.TypeName)){
                animal = animal.Where(s => s.AnimalType.TypeName.ToLower().Contains(search.TypeName.ToLower()));
            }
            if (search.AquisitionDate.HasValue){
                animal = animal.Where(s => s.AquisitionDate == search.AquisitionDate);
            }
            if (search.Age.HasValue){
                int num = -1 * search.Age ?? default(int);
                animal = animal.Where(s => s.DOB < (DateTime.Now.AddYears(num)));
            }
            if (search.Age.HasValue){
                int num = -1 * search.Age ?? default(int);
                animal = animal.Where(s => s.DOB > (DateTime.Now.AddYears(num-1)));
            }
            
            switch(search.Order.ToLower())    
            {
            default:
                animal = animal.OrderBy(u => u.AnimalType.Species).AsQueryable();
                break;
            case "animalname":
                animal = animal.OrderBy(u => u.AnimalName.AsQueryable() );
                break;
            case "animalclass":
                animal = animal.OrderBy(u => u.AnimalType.AnimalClass.AsQueryable() );
                break;
            case "typename":
                animal = animal.OrderBy(u => u.AnimalType.TypeName.AsQueryable() );
                break;
            }   
            var animalReturn = animal.Skip((search.Page - 1) * search.PageSize)
            .Take(search.PageSize)
            .ToList();
            return animalReturn;
        }
 
    }
} 
