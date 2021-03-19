using ZooManagement.Models.Database;
using System;


namespace ZooManagement.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }

        public int Id => _animal.Id;
        public int AnimalType_id => _animal.AnimalType_Id;
        public string AnimalName => _animal.AnimalName;
        public string Sex => _animal.Sex;
        public DateTime AquisitionDate => _animal.AquisitionDate;
        public DateTime DOB => _animal.DOB;

        public string EnclosureName =>_animal.Enclosure.EnclosureName;

        public int Enclosure_Id => _animal.Enclosure_Id;

    }

}