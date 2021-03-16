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
    public interface IAnimalTypeRepo
    {
        AnimalType GetAnimalTypebyName(String TypeName);
        AnimalType CreateAnimalType(CreateAnimalTypeRequest animaltype );
        // Animal GetAmimalById(int id);
        // Animal Create(CreateAnimalRequest newAnimal);
   
    }

    public class AnimalTypeRepo : IAnimalTypeRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalTypeRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        public AnimalType GetAnimalTypebyName(string TypeName)
        {
            return _context.AnimalType
                .SingleOrDefault(animaltype => animaltype.TypeName == TypeName);
        }
        public AnimalType CreateAnimalType(CreateAnimalTypeRequest animaltype)
        {
             var insertResponse = _context.AnimalType.Add(new AnimalType
            {
                TypeName = animaltype.TypeName,
                Species = animaltype.Species,
                AnimalClass = animaltype.AnimalClass,
                
            });
            _context.SaveChanges();
            return insertResponse.Entity;
        }
    }
}