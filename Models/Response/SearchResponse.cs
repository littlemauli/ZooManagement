using ZooManagement.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooManagement.Models.Response
{
    public class SearchResponse
    {
        public List<ExtendedAnimalDetails> AnimalList {get; private set;}

        public SearchResponse(List<Animal> list)
        {
           AnimalList = list.Select((x)=> new ExtendedAnimalDetails(x)).ToList();           
        }
    }

}