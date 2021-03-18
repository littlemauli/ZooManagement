using System;

namespace ZooManagement.Models.Request
{
    // public class SearchRequest
    // {
    //     public int Page { get; set; } = 1;
    //     public int PageSize { get; set; } = 10;
    //     public virtual string Filters => "";
    // }
    
    public class AnimalSearchRequest 
    {
    //     private string _search;
        
    //     public string Search
    //     {
    //         get => _search?.ToLower();
    //         set => _search = value;

    //     }
        public int Page { get; set; } 
        public int PageSize { get; set; } 
        public string AnimalName { get; set; }
        
        public string Species { get; set; }
        public string AnimalClass { get; set; }
        public string TypeName { get; set; }

        public DateTime? AquisitionDate { get; set; }

        public int? Age { get; set; }

        public string Order {get; set;}

        // public override string Filters
        // {
        //     get
        //     {
        //         var filters = "";

        //         if (AnimalName != null)
        //         {
        //             filters += $"&AnimalName={AnimalName}";
        //         }
                
        //         if (Species != null)
        //         {
        //             filters += $"&Species={Species}";
        //         }
                
        //         if (AnimalClass != null)
        //         {
        //             filters += $"&AnimalClass={AnimalClass}";
        //         }
        //         if (TypeName != null)
        //         {
        //             filters += $"&TypeName={TypeName}";
        //         }
                
        //         return filters;
        //     }
        }
    
}