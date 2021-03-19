using ZooManagement.Models.Database;
using System;


namespace ZooManagement.Models.Response
{
    public class EnclosureResponse
    {
        private readonly Enclosure _enclosure;

        public EnclosureResponse(Enclosure enclosure)
        {
            _enclosure = enclosure;
        }

        public int Enclosure_Id => _enclosure.Id;
        public string EnclosureName => _enclosure.EnclosureName;
        public int EnclosureCapacity => _enclosure.EnclosureCapacity;

        public int EnclosureCurrentFill =>_enclosure.Animals.Count;
        
    }

}