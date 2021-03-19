using ZooManagement.Models.Database;
using System;
using System.Collections.Generic;


namespace ZooManagement.Models.Response
{
    public class EnclosureListResponse
    {
        public List<EnclosureResponse> EnclosureList {get; set;} = new List<EnclosureResponse>();

    }
}