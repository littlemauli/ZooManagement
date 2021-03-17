namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }
    
    public class AnimalSearchRequest : SearchRequest
    {
    //     private string _search;
        
    //     public string Search
    //     {
    //         get => _search?.ToLower();
    //         set => _search = value;

    //     }
        public string AnimalName { get; set; }
        public string Species { get; set; }
        public string AnimalClass { get; set; }
        public string TypeName { get; set; }


        public override string Filters
        {
            get
            {
                var filters = "";

                if (AnimalName != null)
                {
                    filters += $"&AnimalName={AnimalName}";
                }
                
                if (Species != null)
                {
                    filters += $"&Species={Species}";
                }
                
                if (AnimalClass != null)
                {
                    filters += $"&AnimalClass={AnimalClass}";
                }
                if (TypeName != null)
                {
                    filters += $"&TypeName={TypeName}";
                }
                
                return filters;
            }
        }


        // public override string Filters => Search == null ? "" : $"&search={Search}";
    }

    // public class PostSearchRequest : SearchRequest
    // {
    //     public int? PostedBy { get; set; }
    //     public override string Filters => PostedBy == null ? "" : $"&postedBy={PostedBy}";
    // }

    // public class FeedSearchRequest : PostSearchRequest
    // {
    //     public int? LikedBy { get; set; }
    //     public int? DislikedBy { get; set; }
        // public override string Filters
        // {
        //     get
        //     {
        //         var filters = "";

        //         if (PostedBy != null)
        //         {
        //             filters += $"&postedBy={PostedBy}";
        //         }
                
        //         if (LikedBy != null)
        //         {
        //             filters += $"&likedBy={LikedBy}";
        //         }
                
        //         if (DislikedBy != null)
        //         {
        //             filters += $"&dislikedBy={DislikedBy}";
        //         }
                
        //         return filters;
        //     }
        // }
    //}
}