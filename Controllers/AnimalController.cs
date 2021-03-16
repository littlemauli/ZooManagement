using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;
using ZooManagement.Models.Database;
using ZooManagement.Models.Response;


namespace ZooManagement.Controllers
{
  [ApiController]
  [Route("/animals")]

  public class AnimalController: ControllerBase
  {
        private readonly IAnimalRepo _animals;
        private readonly IAnimalTypeRepo _animaltypes;

        public AnimalController(IAnimalRepo animals, IAnimalTypeRepo animaltypes)
        {
            _animals = animals;
            _animaltypes = animaltypes;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalUserRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // make a animal type object and an animal object
            // check if animal trpe exists. 
            // if yes, insert only to animal using animal object
            // else insert to animal type and then animal 


            var animaltypeSelect = _animaltypes.GetAnimalTypebyName(newAnimal.TypeName);
            Animal animalcreated ;
           if( animaltypeSelect != null)
            {
                CreateAnimalRequest animal = new CreateAnimalRequest();
                animal.AnimalType_id = animaltypeSelect.Id;
                animal.AnimalName = newAnimal.AnimalName;
                animal.Sex = newAnimal.Sex;
                animal.AquisitionDate =newAnimal.AquisitionDate;
                animal.DOB = newAnimal.DOB;
                animalcreated = _animals.CreateAnimal(animal);
            }
            else
            {
                //populate a createanimaltype animaltype and send it to repo.
                // insert into animal type
                CreateAnimalTypeRequest animaltype = new  CreateAnimalTypeRequest();
                animaltype.TypeName = newAnimal.TypeName;
                animaltype.Species = newAnimal.Species;
                animaltype.AnimalClass = newAnimal.AnimalClass;
                var animaltypecreated = _animaltypes.CreateAnimalType(animaltype);

                CreateAnimalRequest animal = new CreateAnimalRequest();
                animal.AnimalType_id = animaltypecreated.Id;
                animal.AnimalName = newAnimal.AnimalName;
                animal.Sex = newAnimal.Sex;
                animal.AquisitionDate =newAnimal.AquisitionDate;
                animal.DOB = newAnimal.DOB;
                animalcreated = _animals.CreateAnimal(animal);

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

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetAnimal([FromRoute] int id)
        {
            var animal = _animals.GetAnimalbyId(id);
            return new AnimalResponse(animal);
        }

  }

}

