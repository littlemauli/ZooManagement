using Microsoft.AspNetCore.Mvc;
using ZooManagement;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;
using ZooManagement.Models.Database;
using ZooManagement.Models.Response;
using NLog;
using NLog.Config;
using NLog.Targets;
// using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;



namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/animals")]

    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _animals;
        private readonly IAnimalTypeRepo _animaltypes;

        private readonly IEnclosureRepo _enclosures;

        // private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
       // private readonly ILogger<AnimalController> _logger;

        // public AnimalController(ILogger<AnimalController> logger)
        // {
        //     _logger = logger;
        //     _logger.LogDebug(1, "NLog injected into AnimalController");
        // }

        public AnimalController(IAnimalRepo animals, IAnimalTypeRepo animaltypes, IEnclosureRepo enclosures)
        {
            _animals = animals;
            _animaltypes = animaltypes;
            _enclosures = enclosures;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalUserRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
               // _logger.LogError("There is error in input format" + ModelState );
                return BadRequest(ModelState);
            }
            // make a animal type object and an animal object
            // check if animal trpe exists. 
            // if yes, insert only to animal using animal object
            // else insert to animal type and then animal 

            //do a select on enclosure and animal tables. 
            // o/p make a list of enclosure id, max capacity 
            // and current capacity (the count of animals for each enclosure id)
            // assign the first available enclosure if with space to the animal being created
//<List of enclosure respose, enclosure list response>
// id, max count, current capacity(count on animal table)
// read the list, find the first available enclosure. current<max assign that to EEE = 2
//
            var e =_enclosures.GetEnclosureList();
            int Enclosuretouse = 0;
            foreach(EnclosureResponse enc in e.EnclosureList)
            {
                if(enc.EnclosureCurrentFill<enc.EnclosureCapacity)
                {
                    Enclosuretouse = enc.Enclosure_Id;
                    break;
                }
            }
            if (Enclosuretouse !=0)
            {
                var animaltypeSelect = _animaltypes.GetAnimalTypebyName(newAnimal.TypeName);
                Animal animalcreated;
                if (animaltypeSelect != null)
                {
                    CreateAnimalRequest animal = new CreateAnimalRequest();
                    animal.AnimalType_Id = animaltypeSelect.Id;
                    animal.AnimalName = newAnimal.AnimalName;
                    animal.Sex = newAnimal.Sex;
                    animal.AquisitionDate = newAnimal.AquisitionDate;
                    animal.DOB = newAnimal.DOB;
                    animalcreated = _animals.CreateAnimal(animal,Enclosuretouse);
                }
                else
                {
                    //populate a createanimaltype animaltype and send it to repo.
                    // insert into animal type
                    CreateAnimalTypeRequest animaltype = new CreateAnimalTypeRequest();
                    animaltype.TypeName = newAnimal.TypeName;
                    animaltype.Species = newAnimal.Species;
                    animaltype.AnimalClass = newAnimal.AnimalClass;
                    var animaltypecreated = _animaltypes.CreateAnimalType(animaltype);

                    CreateAnimalRequest animal = new CreateAnimalRequest();
                    animal.AnimalType_Id = animaltypecreated.Id;
                    animal.AnimalName = newAnimal.AnimalName;
                    animal.Sex = newAnimal.Sex;
                    animal.AquisitionDate = newAnimal.AquisitionDate;
                    animal.DOB = newAnimal.DOB;
                    animalcreated = _animals.CreateAnimal(animal,Enclosuretouse);

                }
                if (animalcreated == null)
                {
                    return StatusCode(401);
                }
                else
                {
                    return StatusCode(200);
                }
            }
            else{
                return BadRequest(" the enclosures are full");
            }
        
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetAnimal([FromRoute] int id)
        {
            var animal = _animals.GetAnimalbyId(id);
            if (animal == null)
            {
                return StatusCode(401);
            }
            else
            {
                return new AnimalResponse(animal);
            }
        }

        [HttpGet("alltype")]
        public ActionResult<AnimalTypeListResponse> GetAnimalList()
        {
            var typelist = _animaltypes.GetAnimalType();
            return typelist;
        }


        [HttpGet("search")]
        public ActionResult<SearchResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        {
            var animals = _animals.Search(searchRequest);
            SearchResponse animalSearchResult = new SearchResponse(animals);
            return animalSearchResult;
        }

        // [HttpGet("enclosures")]
        // public ActionResult<EnclosureListResponse> GetEnclosureList()
        // {
        //    var enclosureList =_enclosures.GetEnclosureList();
        //    return enclosureList;

        // }

}
}




