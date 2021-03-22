using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) {}
       
        public DbSet<AnimalType> AnimalType { get; set; }
        public DbSet<Animal> Animal { get; set; }

        public DbSet<Enclosure> Enclosure { get; set; }
        public DbSet<Zookeeper> Zookeeper { get; set; }

    }
}