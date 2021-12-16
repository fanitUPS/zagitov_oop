using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class Person
    /// Include properties: name, surname, age, gender
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Name of person
        /// </summary>
        private string _name;

        /// <summary>
        /// Surname of person
        /// </summary>
        private string _surname;

        /// <summary>
        /// Age of person
        /// </summary>
        private int _age;

        /// <summary>
        /// Gender of person
        /// </summary>
        private PersonGender _gender;

        /// <summary>
        /// Constructor of person instance
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="surname">Surname of person</param>
        /// <param name="age">Age of person</param>
        /// <param name="gender">Gender of person</param>
        public Person(string name, string surname, int age, PersonGender gender)
        {
            _name = name;
            _surname = surname;
            _age = age;
            _gender = gender;
        }

        public string Name
        {
            get
            { 
                return _name;
            }
            set
            {
                /*if (!ValidEmail(value))
                    throw new ArgumentException
                        (string.Format
                        ("Email address {0} is in wrong format",
                        value));

                Name = value;*/
            }
        }
        
        public void ValidName(string checkName)
        {

        }
    }
}
