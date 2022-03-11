using System;
using System.Collections.Generic;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class child
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Age of child
        /// </summary>
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value < MinAge || value > AdultAge)
                {
                    throw new ArgumentException
                        ("Entered age is not valid. Valid age " +
                        $"from {MinAge} to {AdultAge} years.");
                }

                base.Age = value;
            }
        }

        /// <summary>
        /// Mother of child
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Father of child
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Name of kindergarten
        /// </summary>
        private string _kinderGarten;

        /// <summary>
        /// Mother of child
        /// </summary>
        public Adult Mother
        {
            get => _mother;
            set => _mother = GenderCheck(value,PersonGender.Female);
        }

        /// <summary>
        /// Father of child
        /// </summary>
        public Adult Father
        {
            get => _father;
            set => _father = GenderCheck(value, PersonGender.Male);
        }

        //TODO: RSDN(+)
        /// <summary>
        /// Name of kindergarten
        /// </summary>
        public string KinderGarten { get; set; }

        /// <summary>
        /// Constructor of child instance
        /// </summary>
        /// <param name="name">Name of child</param>
        /// <param name="surname">Surname of child</param>
        /// <param name="age">Age of child</param>
        /// <param name="gender">Gender of child</param>
        /// <param name="mother">Mother of child</param>
        /// <param name="father">Father of child</param>
        /// <param name="kindergarten">Name of kindergarten</param>
        public Child(string name, string surname, int age, PersonGender gender,
            Adult mother, Adult father, string kindergarten)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            KinderGarten = kindergarten;
        }

        /// <summary>
        /// Constructor of common child instance
        /// </summary>
        /// <param name="surname">Surname of child</param>
        /// <param name="age">Age of child</param>
        /// <param name="mother">Mother of child</param>
        /// <param name="father">Father of child</param>
        /// <param name="kindergarten">Name of kindergarten</param>
        public Child(string surname, int age, Adult mother, Adult father,
            string kindergarten) : base(surname, age)
        {
            Mother = mother;
            Father = father;
            KinderGarten = kindergarten;
        }

        /// <summary>
        /// Check gender of parents
        /// </summary>
        /// <param name="parent">AdultPerson instance</param>
        /// <param name="parentGender">Desired gender</param>
        public Adult GenderCheck(Adult parent, PersonGender parentGender)
        {
            if (parent == null) return parent;

            if (parent.Gender != parentGender)
            {
                throw new ArgumentException
                    ("This parent must has another gender");
            }
            return parent;
        }

        /// <summary>
        /// Info about ChildPerson
        /// </summary>
        /// <returns>String Info</returns>
        public override string Info()
        {
            var info = $"{this.Name} {this.Surname} {this.Age} {this.Gender}";

            if (this.Mother != null)
            {
                info = $"{info}\nMother:{this.Mother.Name} {this.Mother.Surname}";
            }

            if (this.Father != null)
            {
                info = $"{info}\nFather:{this.Father.Name} {this.Father.Surname}";
            }

            info = !string.IsNullOrEmpty(this.KinderGarten) 
                ? $"{info}\nKindergarten:{this.KinderGarten}" 
                : $"{info}\nDoesn't go to kindergarten";

            return info;
        }

        /// <summary>
        /// Create random child
        /// </summary>
        /// <param name="rnd">Random number</param>
        /// <returns>Child</returns>
        public static Child GetRandomChild(Random rnd)
        {
            string[] namesMale = {
                "Karl", "Fanit", "Peter",
                "Robert","Joseph","Gendry",
                "Tom","Ron","Harry",
                "Liam", "Noah", "Oliver",
                "Elijah", "William", "James",
                "Benjamin", "Lucas", "Henry"
            };

            string[] namesFemale = {
                "Dora", "Anna", "Elizabeth",
                "Maria","Marina","Lana",
                "Krista","Sasha","Lara",
                "Olivia", "Emma", "Ava",
                "Charlotte", "Sophia", "Amelia",
                "Isabella", "Mia", "Evelyn"
            };

            var gender = new Dictionary<int, PersonGender>()
            {
                {0, PersonGender.Male},
                {1, PersonGender.Female}
            };

            var child = GetCommonChild(rnd);

            child.Gender = gender[rnd.Next(2)];

            var nameMale = PersonBase.GetRandomName(namesMale, rnd);

            var nameFemale = PersonBase.GetRandomName(namesFemale, rnd);

            var flag = (child.Gender == PersonGender.Male)
                ? child.Name = nameMale
                : child.Name = nameFemale;

            return child;
        }

        /// <summary>
        /// Create common child
        /// </summary>
        /// <param name="rnd">Random int</param>
        /// <returns>Child</returns>
        public static Child GetCommonChild(Random rnd)
        {
            string[] kindergartens = {
                "Water", "Fire", "Air",
                "Cloud", "Earth", "Mars",
                "Twix", "Russia", "Tomsk",
                "Appletree", "Childtime", "EduKids",
                "Harmony", "Kidspace", "Minnieland",
                "MountainStar", "Serendipity", "Sunbeam"
            };

            var parent = Adult.GetRandomPerson(rnd);

            Adult father = null;

            Adult mother = null;

            var surname = parent.Surname;

            if (parent.Gender == PersonGender.Male)
            {
                father = parent;
                if (father.MaritalStatus == MaritalStatus.Married)
                {
                    mother = father.Partner;
                }
            }
            else
            {
                mother = parent;
                if (mother.MaritalStatus == MaritalStatus.Married)
                {
                    father = mother.Partner;
                }
            }
            var rndAge = rnd.Next(MinAge, AdultAge);

            var kindergarten = PersonBase.GetRandomName(kindergartens, rnd);

            return new Child(surname, rndAge, mother, father, kindergarten);
        }

        /// <summary>
        /// How person spend holydays
        /// </summary>
        public override void Holydays()
        {
            Console.WriteLine("Plays with friends in forest (CHILD)");
        }
    }
}
