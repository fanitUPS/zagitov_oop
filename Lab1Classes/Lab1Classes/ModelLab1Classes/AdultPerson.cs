
using System;
using System.Collections.Generic;

namespace ModelLab1Classes
{
    //TODO: RSDN
    /// <summary>
    /// Class adult
    /// </summary>
    public class AdultPerson : PersonBase
    {
        /// <summary>
        /// Adult minimum age
        /// </summary>
        public const int MinAge = 18;

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
        private AdultPerson _partner = null;

        /// <summary>
        /// Place of employment 
        /// </summary>
        private string _job;

        /// <summary>
        /// Passport ID of adult person
        /// </summary>
        public int PassportId
        {
            get => _passportId;
            set => _passportId = value;
        }

        /// <summary>
        /// Patner of adult person
        /// </summary>
        public AdultPerson Partner
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
        public string Job
        {
            get => _job;
            set => _job = value;
        }

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
        public AdultPerson(string name, string surname, int age, PersonGender gender,
            int passportId, MaritalStatus maritalStatus, string job)
            : base(name, surname, age, gender)
        {
            PassportId = passportId;
            MaritalStatus = maritalStatus;
            Job = job;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        public static AdultPerson GetRandomPerson(Random rnd)
        {
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

            int rndAge = rnd.Next(MinAge, MaxAge);
            
            int rndGender = rnd.Next(namesMale.Length);

            //TODO: duplication
            if (rndGender % 2 == 0)
            {
                var name = namesMale[rnd.Next(namesMale.Length)];
                var surname = surenames[rnd.Next(surenames.Length)];
                var id = rnd.Next(1000, 9999);
                var status = martialStatus[rnd.Next(1, 4)];
                var job = jobs[rnd.Next(jobs.Length)];
                var man = new AdultPerson(name, surname, rndAge,
                    PersonGender.Male, id, status, job);
 
                if (status == MaritalStatus.Married)
                {
                    var wifeName = namesFemale[rnd.Next(namesFemale.Length)];
                    var wifeId = rnd.Next(1000, 9999);
                    var wifeJob = jobs[rnd.Next(jobs.Length)];
                    var wife = new AdultPerson(wifeName, surname, rndAge - 5,
                        PersonGender.Female, wifeId, MaritalStatus.Married, wifeJob);
                    man.Partner = wife;
                    wife.Partner = man;
                }

                return man;
            }
            else
            {
                var name = namesFemale[rnd.Next(namesFemale.Length)];
                var surname = surenames[rnd.Next(surenames.Length)];
                var id = rnd.Next(1000, 9999);
                var status = martialStatus[rnd.Next(1, 4)];
                var job = jobs[rnd.Next(jobs.Length)];
                var woman = new AdultPerson(name, surname, rndAge,
                    PersonGender.Female, id, status, job);

                if (status == MaritalStatus.Married)
                {
                    var husbandName = namesMale[rnd.Next(namesMale.Length)];
                    var husbandId = rnd.Next(1000, 9999);
                    var husbandJob = jobs[rnd.Next(jobs.Length)];
                    var husband = new AdultPerson(husbandName, surname, rndAge + 5,
                        PersonGender.Male, husbandId, MaritalStatus.Married, husbandJob);
                    woman.Partner = husband;
                    husband.Partner = woman;
                }

                return woman;
            }
        }
    }
}
