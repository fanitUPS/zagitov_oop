using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class Person
    /// </summary>
    public abstract class PersonBase
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
        /// Adult minimum age
        /// </summary>
        public const int AdultAge = 18;

        /// <summary>
        /// Mininmum age of person
        /// </summary>
        public const int MinAge = 0;

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
        public virtual int Age
        {
            get => _age;
            set => _age = value;
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
        protected PersonBase(string name, string surname, int age,
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
        protected PersonBase() : this ("Fanit", "Zagitov", MaxAge - 10,
            PersonGender.Male)
        { }

        /// <summary>
        /// Constructor of instance for common person
        /// </summary>
        /// <param name="age">Age of person</param>
        /// <param name="gender">Gender of person</param>
        protected PersonBase(string surname ,int age)
        {
            Surname = surname;
            Age = age;
        }
       
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
            
            else if ((_name != null &&
                     (CheckLanguage(text) != CheckLanguage(_name))) ||
                     (_surname != null &&
                     (CheckLanguage(text) != CheckLanguage(_surname))))
            {
                throw new ArgumentException
                    ("Please enter Surname and Name in same language");
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
        /// Check language of name or surname
        /// </summary>
        /// <param name="value">Name or surname</param>
        /// <returns>Language of name or surname</returns>
        public Language CheckLanguage(string value)
        {
            var laguageDictionary = new Dictionary<Language, string>()
            {
                {Language.Russian, @"(^[а-я]+[-]?[а-я]+$)|(^[а-я]$)"},
                {Language.English, @"(^[a-z]+[-]?[a-z]+$)|(^[a-z]$)"}
            };
            
            foreach (var item in laguageDictionary)
            {
                var language = Regex.IsMatch(value.ToLower(),
                    laguageDictionary[item.Key]);
                if (language)
                {
                    return item.Key;
                }
            }
            throw new ArgumentException
                        ("Unknown language.");
        }

        /// <summary>
        /// Info about person
        /// </summary>
        public abstract string Info();

        /// <summary>
        /// How person spend holydays
        /// </summary>
        public abstract void Holydays();

        /// <summary>
        /// Randomizer of names
        /// </summary>
        /// <param name="array">Array of names</param>
        /// <param name="rnd">Randome number</param>
        /// <returns>Name</returns>
        public static string GetRandomName(string[] array, Random rnd)
        {
            return array[rnd.Next(array.Length)];
        }
    }
}