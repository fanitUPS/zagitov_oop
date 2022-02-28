using ModelLab1Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ViewLab1Classes
{
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
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Console.InputEncoding = System.Text.Encoding.Unicode;

            var rnd = new Random();
            
            //TODO: RSDN
            var Adult1 = AdultPerson.GetRandomPerson(rnd);
            var Adult2 = AdultPerson.GetRandomPerson(rnd);
            var Adult3 = AdultPerson.GetRandomPerson(rnd);

            Console.WriteLine(Adult1.Info());
            Console.WriteLine("");
            Console.WriteLine(Adult2.Info());
            Console.WriteLine("");
            Console.WriteLine(Adult3.Info());
            Console.WriteLine("");
            ///Console.WriteLine(child1.Info());
            Console.WriteLine("");

            var personList = new PersonList();
            personList.Add(Adult3);

            Console.WriteLine(personList.ListInfo());


            Console.ReadKey();
        }
        
        /// <summary>
        /// Output in console all elements in PersonList
        /// </summary>
        /// <param name="personList">Instance PersonList</param>
        private static void OutputInConsole(PersonList personList)
        {
            Console.WriteLine("-------------");
            Console.WriteLine(personList.ListInfo());
            Console.WriteLine("-------------");
        }

        /*
        /// <summary>
        /// Inter person from console
        /// </summary>
        /// <returns>Instance person</returns>
        private static Person ReadPerson()
        {


            var defaultPerson = new Person(10, PersonGender.Male);
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
                                    ("Please enter 1 or 2");
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
        */
    }
}
