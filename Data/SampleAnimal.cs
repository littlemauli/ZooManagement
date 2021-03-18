using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System; 


namespace ZooManagement.Data
{
    public static class SampleAnimal
    {
        public static int NumberOfAnimal = 100;
        
        

    private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "1", "Timmy", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "1", "james", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "3", "John", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "3", "Mouchu", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "3", "Lorry", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "4", "Addie", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "4", "Snak", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "5", "Frogy", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "6", "Pipi", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "6", "Carrie", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "1", "Josh", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "2", "Akira", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "3", "Simba", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "4", "Harry", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "5", "Lisa", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "6", "Sam", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "7", "Shek", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "8", "Mufasa", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "9", "JJ", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "10", "Jessica", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "4", "Tim", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "5", "jalli", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "8", "Johny", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "10", "Mouc", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "9", "Lorria", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "5", "Addie", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "9", "Snoot", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "10", "Fady", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "8", "Rock", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "1", "Beauty", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "3", "Phil", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "7", "Armin", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "8", "Ali", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "9", "Constant", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "7", "Roxanne", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "6", "Lilith", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "8", "Tabby", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "9", "Romain", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "4", "Felix", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "2", "Lily", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "10", "Josh", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "9", "Akira", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "8", "Simba", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "7", "Harry", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "6", "Lisa", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "5", "Sam", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "4", "Shek", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "3", "Mufasa", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "2", "JJ", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "1", "Jessica", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "2", "Josh", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "1", "Akira", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "1", "Simba", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "1", "Harry", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "1", "Lisa", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "6", "Sam", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "6", "Shek", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "6", "Mufasa", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "6", "JJ", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "6", "Jessica", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "10", "Tom", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "5", "Dumbo", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "4", "Johny", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "2", "Marco", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "6", "Lorret", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "1", "Addie", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "3", "Shoot", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "9", "Freddy", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "2", "Rocky", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "1", "Adele", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "2", "Angel", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "5", "Kamui", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "6", "Sal", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "9", "Potter", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "1", "Adele", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "3", "Sala", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "4", "Shrek", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "5", "big", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "6", "JoJo", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "9", "Jess", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "1", "Thomas", "Male","2007-10-26", "2006-02-15", "1"},
            new List<string> { "1", "Jake", "Male","2017-12-05", "2016-02-15", "1"},
            new List<string> { "3", "Sam", "Male","1997-01-31", "1996-02-15", "1"},
            new List<string> { "3", "Mike", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "3", "Lady", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "4", "Adele", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "4", "Beauty", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "5", "Jam", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "6", "Corrien", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "6", "Cara", "Female","2000-01-15", "1998-02-15", "2"},

            new List<string> { "10", "Angelo", "Male","2007-10-26", "2006-02-15", "3"},
            new List<string> { "5", "Mark", "Male","2017-12-05", "2016-02-15", "4"},
            new List<string> { "4", "Veenas", "Male","1997-01-31", "1996-02-15", "5"},
            new List<string> { "2", "Lucas", "Male", "1997-01-31", "1996-02-15", "1"},
            new List<string> { "6", "Sasha", "Female","2000-01-31", "1967-02-15", "1"},
            new List<string> { "1", "Sophia", "Female", "2016-05-10", "2006-02-15", "1"},
            new List<string> { "3", "Callum", "Male","2010-07-27", "2009-07-15", "1"},
            new List<string> { "9", "Freddy", "Male", "2019-01-04", "2018-02-15", "2"},
            new List<string> { "2", "Rocky", "Male","2011-08-22", "2010-02-15", "2"},
            new List<string> { "1", "Adele", "Female","2000-01-15", "1998-02-15", "2"},
            
        };
         
        public static IEnumerable<Animal> GetAnimal()
        {
            return Enumerable.Range(0, NumberOfAnimal).Select(CreateRandomAnimal);
        }

        private static Animal CreateRandomAnimal(int index)
        {
          
            return new Animal
            {
                AnimalType_Id = Int32.Parse(_data[index][0]),
                AnimalName = _data[index][1],
                Sex = _data[index][2],
                AquisitionDate = DateTime.Parse(_data[index][3]),
                DOB = DateTime.Parse(_data[index][4]),
                Enclosure_Id = Int32.Parse(_data[index][5]),
            };
        }
    }
}

