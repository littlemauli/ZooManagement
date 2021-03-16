using System.ComponentModel.DataAnnotations;
using System.Web;
using System;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalUserRequest
    {
        [Required]
        [StringLength(140)]
        
        public string TypeName { get; set; }
        public string Species { get; set; }
        public string AnimalClass { get; set; }
        public string AnimalName { get; set; }
        public string Sex { get; set; }
        public DateTime AquisitionDate { get; set; }
        public DateTime DOB {get; set;}
    }
}