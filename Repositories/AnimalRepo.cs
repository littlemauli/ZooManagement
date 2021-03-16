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
                AnimalType_id = animal.AnimalType_id,
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

        
    }
}
