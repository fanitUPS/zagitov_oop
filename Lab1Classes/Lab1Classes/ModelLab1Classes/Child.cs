using System;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class child
    /// </summary>
    class Child : Person
    {
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
        private string _kindergarten;

        /// <summary>
        /// Mother of child
        /// </summary>
        public Adult Mother
        {
            get => _mother;
            set => _mother = value;
        }

        /// <summary>
        /// Father of child
        /// </summary>
        public Adult Father
        {
            get => _father;
            set => _father = value;
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
        public Child(string name, string surname, int age, PersonGender gender,
            Adult mother, Adult father, string kindergarten)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            Kindergarten = kindergarten;
        }
    }
}
