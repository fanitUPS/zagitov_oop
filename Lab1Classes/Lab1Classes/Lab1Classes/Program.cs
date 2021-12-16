using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLab1Classes;

namespace ViewLab1Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("dsd", "sdsd", 3, PersonGender.Female);
            Person person2 = new Person("d", "sd", 2, PersonGender.Female);
            Person person3 = new Person("fanit", "zagitov", 5, PersonGender.Male);
            Person person4 = new Person("faniпа", "zagitov", 5, PersonGender.Male);

            PersonList personList = new PersonList();

            personList.Add(person1);
            personList.Add(person2);
            personList.Delete();
            personList.Add(person3);
            personList.DeleteIndex(0);
            personList.Add(person4);
            var x = personList.SearchIndex(0);
            var y = personList.SearchIndex(3);
            var t = personList.SearchName(person1);
            var e = personList.SearchName(person4);
            personList.Clear();
            personList.Add(person2);
            int len = personList.Lenght;

        }
    }
}
