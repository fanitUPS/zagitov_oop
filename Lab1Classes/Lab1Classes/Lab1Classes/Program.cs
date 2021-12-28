using ModelLab1Classes;
using System;

namespace ViewLab1Classes
{
    /// <summary>
    /// Class program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            PersonList personList1 = new PersonList();

            Person person11 = new Person("fanit", "zagitov",
                58, PersonGender.Male);
            personList1.Add(person11);

            Person person12 = new Person("elsa", "frozen",
                18, PersonGender.Female);
            personList1.Add(person12);

            try
            {
                Person person33 = new Person("ghg", "dsd--ds",
                    18, PersonGender.Female);
                personList1.Add(person33);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Person person13 = new Person("elizabeth", "black",
                25, PersonGender.Female);
            personList1.Add(person13);

            OutputInConcole(personList1, 1);

            PersonList personList2 = new PersonList();

            Person person21 = new Person("James", "Bond",
                30, PersonGender.Male);
            personList2.Add(person21);

            Person person22 = new Person("eva", "red-green",
                23, PersonGender.Female);
            personList2.Add(person22);

            Person person23 = new Person("athena", "greece",
                88, PersonGender.Female);
            personList2.Add(person23);

            OutputInConcole(personList2, 2);

            Console.ReadLine();
            Console.Clear();

            Person person = Person.GetRandomPerson();

            personList1.Add(person);

            try
            {
                personList2.Add(personList1.SearchIndex(1));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            OutputInConcole(personList1, 1);
            OutputInConcole(personList2, 2);

            Console.ReadLine();
            Console.Clear();

            personList1.DeleteIndex(1);

            OutputInConcole(personList1, 1);
            OutputInConcole(personList2, 2);

            Console.ReadLine();
            Console.Clear();

            personList2.Clear();

            OutputInConcole(personList1, 1);
            OutputInConcole(personList2, 2);

            Console.ReadLine();
            Console.Clear();

            Person newPerson = ReadPerson();
            personList2.Add(newPerson);
            OutputInConcole(personList2, 2);
        }

        /// <summary>
        /// Output in console all elements in PersonList
        /// </summary>
        /// <param name="personList">Instance PersonList</param>
        /// <param name="numberList">Number of List</param>
        static void OutputInConcole(PersonList personList, int numberList)
        {
            Console.WriteLine("Persons in list {0}", numberList);
            Console.WriteLine("-------------");
            personList.Show();
            Console.WriteLine("-------------");
        }

        /// <summary>
        /// Inter person from console
        /// </summary>
        /// <returns>Instance person</returns>
        static Person ReadPerson()
        {
            Console.WriteLine("Enter name of person:");
            string name = "default";
            name = Console.ReadLine();

            Console.WriteLine("Enter surname of person:");
            string surname = "default";
            surname = Console.ReadLine();

            Console.WriteLine("Enter age of person:");
            int age = 0;
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Choose gender of person." +
                "Enter 1 for male or 2 for female");
            PersonGender personGender = PersonGender.Male;
            try
            {
                int gender = Convert.ToInt32(Console.ReadLine());
                
                switch (gender)
                {
                    case 1:
                        personGender = PersonGender.Male;
                        break;
                    case 2:
                        personGender = PersonGender.Female;
                        break;
                    default:
                        Console.WriteLine("Enter 1 or 2!!!");
                        break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Person person = new Person(name, surname,
                    age, personGender);
                return person;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
