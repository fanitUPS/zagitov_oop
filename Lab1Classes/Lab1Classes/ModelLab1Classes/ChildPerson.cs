using System;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class child
    /// </summary>
    public class ChildPerson : PersonBase
    {
        /// <summary>
        /// Mother of child
        /// </summary>
        private AdultPerson _mother;

        /// <summary>
        /// Father of child
        /// </summary>
        private AdultPerson _father;

        /// <summary>
        /// Name of kindergarten
        /// </summary>
        private string _kindergarten;

        /// <summary>
        /// Mother of child
        /// </summary>
        public AdultPerson Mother
        {
            get => _mother;
            set => _mother = GenderCheck(value,PersonGender.Female);
        }

        /// <summary>
        /// Father of child
        /// </summary>
        public AdultPerson Father
        {
            get => _father;
            set => _father = GenderCheck(value, PersonGender.Male);
        }

        /// <summary>
        /// Name of kindergarten
        /// </summary>
        public string Kindergarten
        {
            get => _kindergarten;
            set => _kindergarten = value;
        }

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
        public ChildPerson(string name, string surname, int age, PersonGender gender,
            AdultPerson mother, AdultPerson father, string kindergarten)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            Kindergarten = kindergarten;
        }

        /// <summary>
        /// Check gender of parents
        /// </summary>
        /// <param name="parent">AdultPerson instance</param>
        /// <param name="parentGender">Desired gender</param>
        public AdultPerson GenderCheck(AdultPerson parent, PersonGender parentGender)
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

            if (!string.IsNullOrEmpty(this.Kindergarten))
            {
                info = $"{info}\n{this.Kindergarten}";
            }
            else
            {
                info = $"{info}\nDoesn't go to kindergarten";
            }

            return info;
        }
    }
}
