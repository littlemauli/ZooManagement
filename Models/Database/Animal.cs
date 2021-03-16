using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooManagement.Models.Database
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalType_id { get; set; }
        public AnimalType AnimalType { get; set; }
        
        public string AnimalName { get; set; }
        public string Sex { get; set; }
        public DateTime AquisitionDate { get; set; }
        
        public DateTime DOB {get; set;}
        
    }
}