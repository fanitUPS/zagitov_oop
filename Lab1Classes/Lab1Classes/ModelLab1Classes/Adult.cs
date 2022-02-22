
namespace ModelLab1Classes
{
    //TODO: RSDN
    /// <summary>
    /// Class adult
    /// </summary>
    class Adult : Person
    {
        /// <summary>
        /// Passport ID of adult person
        /// </summary>
        private int _passportId;

        /// <summary>
        /// Marital status of person
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

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
        /// Place of employment 
        /// </summary>
        public string Job
        {
            get => _job;
            set => _job = value;
        }

        /// <summary>
        /// Constructor of adult instance
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
    }
}
