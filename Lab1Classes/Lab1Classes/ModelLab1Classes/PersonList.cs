using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLab1Classes
{
    //TODO: XML
    public class PersonList
    {
        //TODO: RSDN
        Person[] personArray = new Person[0];

         //TODO: XML
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
            //TODO: RSDN
            personArray = personArray.Where((source, indexArray) => indexArray != index).ToArray();
        }

        public Person SearchIndex(int index)
        {
            try
            {
                //TODO: лучше исключение
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
            return Array.IndexOf(personArray, person);
        }

        public void Clear()
        {
            Array.Resize(ref personArray, 0);
        }
    }
}
