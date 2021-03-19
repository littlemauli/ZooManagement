using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 


namespace ZooManagement.Data
{
    public static class SampleEnclosure
    {
        public static int NumberOfAnimalEnclosures = 5;
        
        

    private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Lion Enclosure", "10"},
            new List<string> { "Aviary", "10"},
            new List<string> { "Reptile House", "40"},
            new List<string> { "Giraffe Enclosure", "6"},
            new List<string> { "Hippo Enclosure", "10"},
          
        };
         
        public static IEnumerable<Enclosure> GetAnimalEnclosure()
        {
            return Enumerable.Range(0, NumberOfAnimalEnclosures).Select(CreateRandomEnclosures);
        }

        private static Enclosure CreateRandomEnclosures(int index)
        {
          
            
            return new Enclosure
            {
                EnclosureName = _data[index][0],
                EnclosureCapacity = Int32.Parse(_data[index][1]),
            };
        }
    }
}

