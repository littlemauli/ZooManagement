using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;

namespace ZooManagement.Models.Database
{
    public class Zookeeper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string ZookeeperName { get; set; }
        public string ZookeeperSex { get; set; }
      
        [JsonIgnore]
        public ICollection<Enclosure> Enclosures { get; set; } 


        [JsonIgnore]
        public ICollection<Animal> Animals { get; set; } 
    }
}