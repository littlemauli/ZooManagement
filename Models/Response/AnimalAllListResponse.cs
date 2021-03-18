using ZooManagement.Models.Database;
using System;
using System.Collections.Generic;


namespace ZooManagement.Models.Response
{
    public class AnimalAllListResponse
    {
        public List<AnimalAllResponse> AnimalAllResponseList {get; set;} = new List<AnimalAllResponse>();

        public AnimalAllListResponse(List<Animal> list)
        {
            // AnimalAllListResponse listStuff = new AnimalAllListResponse();
            // foreach (var item in list)
            // {

            //     AnimalAllResponse newAnimalStuff = new AnimalAllResponse(){item.AnimalName, item.Sex, item.AquisitionDate, 
            //     item.DOB,item.TypeName,item.Species, item.AnimalClass
                    
            //     }

            //           ListStuff.add(newAnimalStuff)     
            //     // AnimalAllListResponse.Append(item.AnimalName, item.Sex, item.AquisitionDate, 
            //     // item.DOB,item.TypeName,item.Species, item.AnimalClass )
            // }


            // List<Animal> temp = new List<Animal>;
            // AnimalAllListResponse listStuff = new AnimalAllListResponse(temp);
            // foreach (var item in list)
            // {
            //     listStuff.Add(new AnimalAllResponse {AnimalName = item.AnimalName, Sex = item.Sex, 
            //     AquisitionDate = item.AquisitionDate, 
            //     DOB = item.DOB,TypeName = item.TypeName,Species = item.Species, AnimalClass= item.AnimalClass});
            // }

            foreach (var item in list)
            {
                AnimalAllResponse anRes = new AnimalAllResponse(item);
                AnimalAllResponseList.Add(anRes);
            }
           
        }
    }

}