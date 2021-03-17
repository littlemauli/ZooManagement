using ZooManagement.Models.Database;
using System;
using System.Collections.Generic;


namespace ZooManagement.Models.Response
{
    public class AnimalTypeListResponse
    {
    // {
    //     private readonly Animal _animal;

    //     public AnimalResponse(Animal animal)
    //     {
    //         _animal = animal;
    //     }
    //  public List<AnimalTypeResponse> AnimalTypeList {get; set;} = new List<AnimalTypeResponse>();
        public List<String> AnimalTypeList {get; set;} = new List<String>();

    }
}

