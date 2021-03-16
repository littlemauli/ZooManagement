using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ZooManagement.Models.Database
{
    public class AnimalType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string TypeName { get; set; }
        public string Species { get; set; }
        public string AnimalClass { get; set; }
       
        public ICollection<Animal> Posts { get; set; } = new List<Animal>();
        
    }
}