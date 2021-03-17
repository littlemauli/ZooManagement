using ZooManagement.Models.Database;
using System;


namespace ZooManagement.Models.Response
{
    public class AnimalAllResponse
    {
        private readonly Animal _animal;
        private readonly AnimalType _animaltype;

        public AnimalAllResponse(Animal animal, AnimalType animaltype)
        {
            _animal = animal;
            _animaltype =animaltype;
        }

        public int Id => _animal.Id;
        public int AnimalType_id => _animal.AnimalType_id;
        public string AnimalName => _animal.AnimalName;
        public string Sex => _animal.Sex;
        public DateTime AquisitionDate => _animal.AquisitionDate;
        public DateTime DOB => _animal.DOB;
        public string TypeName => _animaltype.TypeName;
        public string Species => _animaltype.Species;
        public string AnimalClass => _animaltype.AnimalClass;

    }

}