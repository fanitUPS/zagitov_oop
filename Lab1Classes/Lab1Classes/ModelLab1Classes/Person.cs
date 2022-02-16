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
        public const int MaxAge = 135;

        /// <summary>
        /// Name of person
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = Validation(value);
        }

        /// <summary>
        /// Surname of person
        /// </summary>
        public string Surname
        {
            get => _surname;
            set => _surname = Validation(value);
        }
        /// <summary>
        /// Age of person
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0 || value > MaxAge)
                {
                    throw new ArgumentException
                        ("Entered age is not valid. Valid age " +
                        $"from 1 to {MaxAge} years.");
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
        public Person() : this ("Fanit", "Zagitov", MaxAge - 10,
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
        /// Changes text to valid form
        /// </summary>
        /// <param name="text">Name or surname</param>
        /// <returns>Valid text</returns>
        public string Validation(string text)
        {
            if (!ValidName(text) || SpaceInName(text))
            {
                throw new ArgumentException("Entered name or surname is not " +
                    "valid. You must use Latin or Cyrillic alphabet.");
            }

            return ChangeString(text);
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

            string[] surenames = {
                "Potter", "Zagitov", "Griffin",
                "Stalin","Churchill","Pitt",
                "Putin","Glinka","Snow"
            };

            string[] namesFemale = {
                "Dora", "Anna", "Elizabeth",
                "Maria","Marina","Lana",
                "Krista","Sasha","Lara"
            };

            int rndAge = rnd.Next(MaxAge);
            
            int rndGender = rnd.Next(namesMale.Length);

            if (rndGender % 2 == 0)
            {
                return new Person(namesMale[rnd.Next(namesMale.Length)],
                    surenames[rnd.Next(surenames.Length)], rndAge, PersonGender.Male);
            }
            else
            {
                return new Person(namesFemale[rnd.Next(namesFemale.Length)],
                    surenames[rnd.Next(surenames.Length)], rndAge, PersonGender.Female);
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