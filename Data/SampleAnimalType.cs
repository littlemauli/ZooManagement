using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 


namespace ZooManagement.Data
{
    public static class SampleAnimalType
    {
        public static int NumberOfAnimalTypes = 10;
        
        

    private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Lion", "Feline", "Mammal"},
            new List<string> { "Tiger", "Feline", "Mammal"},
            new List<string> { "Barn Owl", "Owl", "Bird"},
            new List<string> { "Peruvian Pelican", "Pelican", "Bird"},
            new List<string> { "Lorikeet", "Parrot", "Bird"},
            new List<string> { "Ader", "Snake", "Reptile"},
            new List<string> { "Boa Constrictor", "Snake", "Reptile"},
            new List<string> { "Golden Frog", "Frog", "Amphibian" },
            new List<string> { "Red Bellied Piranha", "Piranha", "Fish" },
            new List<string> { "Koi Carp", "Carp", "Fish" },
            
        };
         
        public static IEnumerable<AnimalType> GetAnimalTypes()
        {
            return Enumerable.Range(0, NumberOfAnimalTypes).Select(CreateRandomAnimalTypes);
        }

        private static AnimalType CreateRandomAnimalTypes(int index)
        {
          
            
            return new AnimalType
            {
                TypeName = _data[index][0],
                Species = _data[index][1],
                AnimalClass = _data[index][2],
            };
        }
    }
}

