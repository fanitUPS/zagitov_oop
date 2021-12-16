using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProgrammLab1Classes;

namespace ModelProgrammLab1Classes
{
    public class Person
    {
        public string Name;

        public string Surname;

        public int Age;

        public EnumGender Gender;

        public Person(string name, string surname, int age, EnumGender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
    }
    



}
