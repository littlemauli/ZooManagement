using System.ComponentModel.DataAnnotations;
using System.Web;
using System;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalTypeRequest
    {
        public string TypeName { get; set; }
        public string Species { get; set; }
        public string AnimalClass { get; set; }


    }
}

