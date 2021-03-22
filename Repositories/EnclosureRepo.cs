using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 
using System.Security.Cryptography;

namespace ZooManagement.Repositories
{
    public interface IEnclosureRepo
    {
        // EnclosureResponse GetEnclosurebyId(int id);
        EnclosureListResponse GetEnclosureList();
   
    }

    public class EnclosureRepo : IEnclosureRepo
    {
        private readonly ZooManagementDbContext _context;

        public EnclosureRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        // public EnclosureResponse GetEnclosurebyId(int id)
        // {

        //     var enclosure = _context.Enclosure
        //         .Include(a => a.Animals)
        //         .SingleOrDefault(enclosure => enclosure.Id == id);
        //         EnclosureResponse encRes = EnclosureResponse(enclosure);
        //         return encRes;
        //  }


        public EnclosureListResponse GetEnclosureList() 
        {
        

            EnclosureListResponse encList = new EnclosureListResponse();
            
            encList.EnclosureList = _context.Enclosure
                .Include(b => b.Animals)
                .Select(a=>new EnclosureResponse(a))
                .ToList();
           
           return encList;

        }
    }

}