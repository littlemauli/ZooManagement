using ZooManagement.Models.Database;
using System;


namespace ZooManagement.Models.Response
{
    public class AnimalTypeResponse
    {
        private readonly AnimalType _animaltype;

        public AnimalTypeResponse(AnimalType animaltype)
        {
            _animaltype = animaltype;
        }

        public int Id => _animaltype.Id;
        public string TypeName => _animaltype.TypeName;
        public string Species => _animaltype.Species;
        public string AnimalClass => _animaltype.AnimalClass;

    }

}