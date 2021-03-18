using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;

namespace ZooManagement.Models.Database
{
    public class Enclosure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string EnclosureName { get; set; }
        public int EnclosureCapacity { get; set; }
      
        [JsonIgnore]
        public ICollection<Animal> Animals { get; set; } 
    }
}