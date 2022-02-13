using ModelLab1Classes;
using System;
using System.Collections.Generic;

namespace ViewLab1Classes
{
    //TODO: RSDN(+)
    /// <summary>
    /// Class program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        private static void Main(string[] args)
        {
            var personList1 = new PersonList();

            var person11 = new Person("fanit", "zagitov",
                58, PersonGender.Male);
            personList1.Add(person11);

            var person12 = new Person("elsa", "frozen",
                18, PersonGender.Female);
            personList1.Add(person12);

            try
            {
                var person33 = new Person("ghg", "dsd--ds",
                    18, PersonGender.Female);
                personList1.Add(person33);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            var person13 = new Person("elizabeth", "black",
                25, PersonGender.Female);
            personList1.Add(person13);

            Console.WriteLine("Person in List 1");
            OutputInConcole(personList1);

            var personList2 = new PersonList();

            var person21 = new Person("James", "Bond",
                30, PersonGender.Male);
            personList2.Add(person21);

            var person22 = new Person("eva", "red-green",
                23, PersonGender.Female);
            personList2.Add(person22);

            var person23 = new Person("athena", "greece",
                88, PersonGender.Female);
            personList2.Add(person23);

            Console.WriteLine("Person in List 2");
            OutputInConcole(personList2);

            Console.ReadLine();
            Console.Clear();

            var person = Person.GetRandomPerson();

            personList1.Add(person);

            try
            {
                personList2.Add(personList1.SearchByIndex(1));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Person in List 1");
            OutputInConcole(personList1);
            Console.WriteLine("Person in List 2");
            OutputInConcole(personList2);

            Console.ReadLine();
            Console.Clear();

            personList1.DeleteByIndex(1);

            Console.WriteLine("Person in List 1");
            OutputInConcole(personList1);
            Console.WriteLine("Person in List 2");
            OutputInConcole(personList2);

            Console.ReadLine();
            Console.Clear();

            personList2.Clear();

            Console.WriteLine("Person in List 1");
            OutputInConcole(personList1);
            Console.WriteLine("Person in List 2");
            OutputInConcole(personList2);

            Console.ReadLine();
            Console.Clear();

            var newPerson = ReadPerson();
            personList2.Add(newPerson);
            Console.WriteLine("Person in List 2");
            OutputInConcole(personList2);
        }

        //TODO: Несоответствие XML-комментария сигнатуре метода(+) 
        /// <summary>
        /// Output in console all elements in PersonList
        /// </summary>
        /// <param name="personList">Instance PersonList</param>
        static void OutputInConcole(PersonList personList)
        {
            Console.WriteLine("-------------");
            Console.WriteLine(personList.ListInfo());
            Console.WriteLine("-------------");
        }

        /// <summary>
        /// Inter person from console
        /// </summary>
        /// <returns>Instance person</returns>
        static Person ReadPerson()
        {
            var defaultPerson = new Person();
            var actionsTupleList = new List<(Action Action, string Message)>
            {
                (
                    () => 
                    { 
                        defaultPerson.Name = Console.ReadLine();
                    },
                    "Enter name of person:"),
                (
                    () =>
                    {
                        defaultPerson.Surname = Console.ReadLine();
                    },
                    "Enter surname of person:"),
                (
                    () =>
                    {
                        defaultPerson.Age =
                            Convert.ToInt32(Console.ReadLine());
                    },
                    "Enter age of person:"),
                (
                    () =>
                    {
                        int gender = Convert.ToInt32(Console.ReadLine());
                        switch (gender)
                        {
                            case 1:
                            {
                                defaultPerson.Gender = PersonGender.Male;
                                return;
                            }
                            case 2:
                            {
                                defaultPerson.Gender = PersonGender.Female;
                                return;
                            }
                            default:
                            {
                                throw new ArgumentException
                                    ("Enter 1 or 2!!!");
                            }
                        }
                    },
                    "Choose gender of person." +
                    "Enter 1 for male or 2 for female")
            };

            foreach (var actionTuple in actionsTupleList)
            {
                ActionHandler(actionTuple.Action, actionTuple.Message);
            }
            return defaultPerson;
        }

        /// <summary>
        /// Handler of enter person from console
        /// </summary>
        /// <param name="action">Executable action</param>
        /// <param name="inputMessage">Message to action</param>
        private static void ActionHandler(Action action, string inputMessage)
        {
            while (true)
            {
                Console.WriteLine(inputMessage);
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    if (e is ArgumentException
                        || e is FormatException)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Try again!");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
