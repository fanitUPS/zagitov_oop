using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProgrammLab1Classes;

namespace MainProgrammLab1Classes
{

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("dsd", "sdsd", 3, EnumGender.Female);

            PersonList personList = new PersonList();

            personList.Add(person1);

        }
    }
}
