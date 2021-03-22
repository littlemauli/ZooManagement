using System.ComponentModel.DataAnnotations;
using System.Web;
using System;
using System.Collections.Generic;

namespace ZooManagement.Models.Request
{
    public class CreateZookeeperRequest
    {
     
        public string ZookeeperName { get; set; }
        public string ZookeeperSex { get; set; }
        public List<int> EnclosureIds {get; set;}
        
    

    }
}

