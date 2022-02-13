using System;
using System.Text.RegularExpressions;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class Person
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
        /// Max age of person
        /// </summary>
        public const int maxAge = 135;

        /// <summary>
        /// Name of person
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (!ValidName(value) || SpaceInName(value))
                {
                    throw new ArgumentException("Entered name is not valid");
                }

                _name = ChangeString(value);
            }
        }

        /// <summary>
        /// Surname of person
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (!ValidName(value) || SpaceInName(value))
                {
                    throw new ArgumentException
                        ("Entered surname is not valid");
                }

                _surname = ChangeString(value);
            }
        }

        /// <summary>
        /// Age of person
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > maxAge)
                {
                    throw new ArgumentException
                        ("Entered age is not valid");
                }

                _age = value;
            }
        }

        /// <summary>
        /// Gender of person
        /// </summary>
        public PersonGender Gender { get; set; }

        /// <summary>
        /// Constructor of person instance
        /// </summary>
        /// <param name="name">Name of person</param>
        /// <param name="surname">Surname of person</param>
        /// <param name="age">Age of person</param>
        /// <param name="gender">Gender of person</param>
        public Person(string name, string surname, int age,
            PersonGender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Person() : this ("Fanit", "Zagitov", maxAge - 10,
            PersonGender.Male)
        { }
       
        /// <summary>
        /// Validation name and surname of person
        /// </summary>
        /// <param name="checkName">Name or surname for validation</param>
        /// <returns>True for valid name or surname</returns>
        public bool ValidName(string checkName)
        {
            var isValid = Regex.IsMatch(checkName.ToLower(),
                @"(^[a-z]+[-]?[a-z]+$)|(^[а-я]+[-]?[а-я]+$)|(^[a-zа-я]$)");

            return isValid;
        }

        /// <summary>
        /// Search space in string
        /// </summary>
        /// <param name="checkName">Name or surname</param>
        /// <returns>True for space in string</returns>
        public bool SpaceInName(string checkName)
        {
            return Regex.IsMatch(checkName, @" ");
        }

        /// <summary>
        /// Change name to valid form
        /// </summary>
        /// <param name="changeName">Changing name</param>
        /// <returns>Valid form of name</returns>
        public string ChangeString(string changeName)
        {
            char firstLitter = changeName.ToUpper()[0];
            changeName = firstLitter + changeName.ToLower().Remove(0, 1);
            if (Regex.IsMatch(changeName, @"-"))
            {
                var firstName = Regex.Match(changeName, @"^\w*[^-]");
                var secondName = Regex.Match(changeName, @"-\w+");
                char litterSecondName = secondName.ToString().ToUpper()[1];
                changeName = firstName.ToString()+ "-" + litterSecondName +
                    secondName.ToString().ToLower().Remove(0, 2);
            }
            return changeName;
        }

        /// <summary>
        /// Create random instance of person 
        /// </summary>
        /// <returns>Instance of person</returns>
        public static Person GetRandomPerson()
        {
            Random rnd = new Random();

            string[] namesMale = {
                "Karl", "Fanit", "Peter",
                "Robert","Joseph","Gendry",
                "Tom","Ron","Harry"
            };

            string[] sureNames = {
                "Potter", "Zagitov", "Griffin",
                "Stalin","Churchill","Pitt",
                "Putin","Glinka","Snow"
            };

            string[] namesFemale = {
                "Dora", "Anna", "Elizabeth",
                "Maria","Marina","Lana",
                "Krista","Sasha","Lara"
            };

            int rndAge = rnd.Next(0, 134);
            
            int rndGender = rnd.Next(0, 8);

            if (rndGender % 2 == 0)
            {
                return new Person(namesMale[rnd.Next(0, 8)],
                    sureNames[rnd.Next(0, 8)], rndAge, PersonGender.Male);
            }
            else
            {
                return new Person(namesFemale[rnd.Next(0, 8)],
                    sureNames[rnd.Next(0, 8)], rndAge, PersonGender.Female);
            }
        }

        /// <summary>
        /// Info about person
        /// </summary>
        public string Info()
        {
            return $"{this._name} {this._surname} {this._age} {this.Gender}";
        }
    }
}