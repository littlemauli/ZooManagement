using System.ComponentModel.DataAnnotations;
using System.Web;
using System;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        public int AnimalType_id { get; set; }
     
        public string AnimalName { get; set; }
        public string Sex { get; set; }
        public DateTime AquisitionDate { get; set; }
        
        public DateTime DOB {get; set;}


    }
}

