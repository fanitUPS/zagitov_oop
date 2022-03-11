using System;
using System.Collections.Generic;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class adult
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Age of adult
        /// </summary>
        public override int Age
        {
            get => base.Age;
            set
            {
                if (value <= AdultAge || value > MaxAge)
                {
                    throw new ArgumentException
                        ("Entered age is not valid. Valid age " +
                        $"from {AdultAge} to {MaxAge} years.");
                }

                base.Age = value;
            }
        }

        /// <summary>
        /// Passport ID of adult person
        /// </summary>
        private int _passportId;

        /// <summary>
        /// Marital status of adult person
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Patner of adult person
        /// </summary>
        private Adult _partner = null;
        
        /// <summary>
        /// Min ID
        /// </summary>
        private const int _minId = 1000;

        /// <summary>
        /// Max ID
        /// </summary>
        private const int _maxId = 999999;

        /// <summary>
        /// Passport ID of adult person
        /// </summary>
        public int PassportId
        {
            get => _passportId;
            set
            {
                if (value <= _minId || value > _maxId)
                {
                    throw new ArgumentException
                        ("Entered Id is not valid. Valid Id " +
                        $"from {_minId} to {_maxId}.");
                }

                _passportId = value;
            }
        }

        /// <summary>
        /// Patner of adult person
        /// </summary>
        public Adult Partner
        {
            get => _partner;

            set
            {
                if (this.Gender == value.Gender)
                {
                    throw new ArgumentException
                        ("Gender of partners must be different");
                }

                _partner = value;
            }
        }

        /// <summary>
        /// Place of employment 
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Constructor of adult person instance
        /// </summary>
        /// <param name="name">Name of adult</param>
        /// <param name="surname">Surname of adult</param>
        /// <param name="age">Age of adult</param>
        /// <param name="gender">Gender of adult</param>
        /// <param name="passportId">PassportId of adult</param>
        /// <param name="maritalStatus">Martial status of person</param>
        /// <param name="job">Job of person</param>
        public Adult(string name, string surname, int age, PersonGender gender,
            int passportId, MaritalStatus maritalStatus, string job)
            : base(name, surname, age, gender)
        {
            PassportId = passportId;
            MaritalStatus = maritalStatus;
            Job = job;
        }

        /// <summary>
        /// Constructor of common adult person instance
        /// </summary>
        /// <param name="surname">Surname of adult</param>
        /// <param name="age">Age of adult</param>
        /// <param name="passportId">>PassportId of adult</param>
        /// <param name="maritalStatus">Martial status of person</param>
        /// <param name="job">Job of person</param>
        public Adult(string surname, int age, int passportId,
            MaritalStatus maritalStatus, string job)
            : base(surname, age)
        {
            PassportId = passportId;
            MaritalStatus = maritalStatus;
            Job = job;
        }

        /// <summary>
        /// Get info about Adult
        /// </summary>
        /// <returns>String info</returns>
        public override string Info()
        {
            var info = $"{this.Name} {this.Surname} {this.Age} {this.Gender}" +
                $" {this.PassportId} \n{this.MaritalStatus}";

            if (this.MaritalStatus == MaritalStatus.Married)
            {
                info = $"{info} {this.Partner.Name} {this.Partner.Surname}";
            }

            info = !string.IsNullOrEmpty(this.Job) 
                ? $"{info} {this.Job}" 
                : $"{info} Jobless";
            
            return info;
        }
        
        /// <summary>
        /// Create random instance of adult person
        /// </summary>
        /// <param name="rnd">Random number</param>
        /// <returns>Instance of AdultPerson</returns>
        public static Adult GetRandomPerson(Random rnd)
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

            var femaleName = PersonBase.GetRandomName(namesFemale, rnd);
            var maleName = PersonBase.GetRandomName(namesMale, rnd);

            var man = Adult.GetCommonAdult(rnd);
            man.Gender = PersonGender.Male;

            var woman = Adult.GetCommonAdult(rnd);
            woman.Gender = PersonGender.Female;

            man.Name = maleName;
            woman.Name = femaleName;

            if (man.MaritalStatus == MaritalStatus.Married ||
                woman.MaritalStatus == MaritalStatus.Married)
            {
                woman.Surname = man.Surname;
                woman.MaritalStatus = MaritalStatus.Married;
                man.MaritalStatus = MaritalStatus.Married;
                man.Partner = woman;
                woman.Partner = man;
            }

            return (rnd.Next(2) == 1)
                ? man
                : woman; 
        }

        /// <summary>
        /// Create pattern of human
        /// </summary>
        /// <param name="rnd">Rnd numbers</param>
        /// <returns>Common human</returns>
        public static Adult GetCommonAdult(Random rnd)
        {
            string[] surenames = {
                "Potter", "Zagitov", "Griffin",
                "Stalin","Churchill","Pitt",
                "Putin","Glinka","Snow",
                "Smith", "Johnson", "Williams",
                "Brown", "Jones", "Garcia",
                "Miller", "Davis", "Rodriguez"
            };

            string[] jobs = {
                "Waiter", "Paramedic", "Dentist",
                "Train conductor", "Nurse", "Electrician",
                "Doctor", "Businessman", "American football player",
                "Student", "Surgeon", "Doorman", "Secretary",
                "Soldier", "Repairman", "Scientist", "Reporter",
                "Construction worker", "Professor", "Police officer",
                "Postman", "Photographer", "Pilot", "Catholic nun"
            };

            var martialStatus = new Dictionary<int, MaritalStatus>()
            {
                {1, MaritalStatus.Divorced},
                {2, MaritalStatus.Married},
                {3, MaritalStatus.Single},
                {4, MaritalStatus.Widowed}
            };

            var rndAge = rnd.Next(AdultAge + 1, MaxAge);

            var surname = PersonBase.GetRandomName(surenames, rnd);

            var status = martialStatus[rnd.Next(1, martialStatus.Count + 1 )];

            var job = PersonBase.GetRandomName(jobs, rnd);

            var id = rnd.Next(_minId, _maxId);

            return new Adult(surname, rndAge, id, status, job);
        }

        /// <summary>
        /// How person spend holydays
        /// </summary>
        public override void Holydays()
        {
            Console.WriteLine("All day watch TV (ADULT)");
        }
    }

}
