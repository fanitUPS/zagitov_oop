using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProgrammLab1Classes
{
    public class PersonList
    {
        Person[] personArray = new Person[0];

        int countArray = 0;
        int indexArray = -1;
        public void Add(Person person)
        {
            countArray++;
            Array.Resize(ref personArray, countArray);
            indexArray++;
            personArray[indexArray] = person;
        }

        /*public void Show(Person[] personArray)
        {
            foreach(Person person in personArray)
            {
                Console.Write(person.Name + " " + person.Surname + " " + person.Age + " " + person.Gender + " ");
                Console.WriteLine("");
            }
        }
        */
    }
}
