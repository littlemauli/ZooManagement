using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 
using ZooManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Request;




namespace ZooManagement.Data
{
    public static class SampleZookeeper
    {
        public static int NumberOfZookeepers = 5;
        // private static ZooManagementDbContext _context{get; set;}

        // static SampleZookeeper(ZooManagementDbContext context)
        // {
        //     _context = context;
        // }
        private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "John", "Male"},
            new List<string> { "Richard", "Male"},
            new List<string> { "Maria", "Female"},
            new List<string> { "Jiliet", "Female"},
            new List<string> { "Romeo", "Male"},
                       
        };
    
        public static IEnumerable<Zookeeper> GetZookeeper(ZooManagementDbContext context)
        {
  
            return Enumerable.Range(0, NumberOfZookeepers).Select(i => CreateRandomZookeeper(i, context));
        }
        private static Zookeeper CreateRandomZookeeper(int index,ZooManagementDbContext context)
        {
            var random = new Random();
                int i = random.Next(1,6);
                int j = random.Next(1,6);

                var encI = context.Enclosure
                            .Single(e => e.Id == i);
                var encJ = context.Enclosure
                        .Single(e => e.Id == j);
                  
            var zk = new Zookeeper
            {
                ZookeeperName = _data[index][0],
                ZookeeperSex = _data[index][1],
                Enclosures = encI == encJ ? new List<Enclosure>(){encI} : new List<Enclosure>(){encI,encJ}
            };
            return zk;
        }
    }
}