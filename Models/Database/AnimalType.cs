using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
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
       
       [JsonIgnore]
       public ICollection<Animal> Animals { get; set; } 
        
    }
}