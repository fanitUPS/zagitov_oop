using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLab1Classes
{
    public class PersonList
    {
        Person[] personArray = new Person[0];

        public int Lenght
        {
            get 
            { 
                return personArray.Length;
            }
        }



        public void Add(Person person)
        {
            int countArray = personArray.Length;
            Array.Resize(ref personArray, countArray + 1);
            int endIndexArray = countArray;
            personArray[endIndexArray] = person;
        }

        public void Delete()
        {
            int countArray = personArray.Length;
            Array.Resize(ref personArray, countArray - 1);
        }

        
        public void DeleteIndex(int index)
        {
            personArray = personArray.Where((source, indexArray) => indexArray != index).ToArray();
        }

        public Person SearchIndex(int index)
        {
            try
            {
                var findPerson = personArray[index];
                return findPerson;
            }
            catch
            {
                return null;
            }
            
        }

        
        public int SearchName(Person person)
        {
            var indexOfElement = Array.IndexOf(personArray, person);
            return indexOfElement;
        }

        public void Clear()
        {
            Array.Resize(ref personArray, 0);
        }



    }
}
