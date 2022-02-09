using ModelLab1Classes;
using System;
using System.Collections.Generic;

namespace ViewLab1Classes
{
    //TODO: RSDN
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
                personList2.Add(personList1.SearchIndex(1));
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

            personList1.DeleteIndex(1);

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

        //TODO: Несоответствие XML-комментария сигнатуре метода 
        /// <summary>
        /// Output in console all elements in PersonList
        /// </summary>
        /// <param name="personList">Instance PersonList</param>
        /// <param name="numberList">Number of List</param>
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
            var validName = false;
            var validSurname = false;
            var validAge = false;
            var validGender = false;

            while (!(validName && validSurname && validAge && validGender))
            {
                if (!validName)
                {
                    //TODO: дубль
                    Console.WriteLine("Enter name of person:");
                    //TODO: дубль
                    Name: 
                    try
                    {
                        defaultPerson.Name = Console.ReadLine();
                        validName = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Try again!");
                        goto Name;
                    }
                }
                if (!validSurname)
                {
                    //TODO: дубль
                    Console.WriteLine("Enter surname of person:");
                    Surname:
                    try
                    {
                        defaultPerson.Surname = Console.ReadLine();
                        validSurname = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Try again!");
                        goto Surname;
                    }
                }
                if (!validAge)
                {
                    //TODO: дубль
                    int age = 0;
                    Console.WriteLine("Enter age of person:");
                    //TODO: goto o_O
                    Age:
                    try
                    {
                        age = Convert.ToInt32(Console.ReadLine());
                        defaultPerson.Age = age;
                        validAge = true;
                    }
                    catch (FormatException e1)
                    {
                        Console.WriteLine(e1.Message);
                        Console.WriteLine("Try again!");
                        goto Age;
                    }
                    catch (ArgumentException e2)
                    {
                        Console.WriteLine(e2.Message);
                        Console.WriteLine("Try again!");
                        goto Age;
                    }
                }
                if (!validGender)
                {
                    //TODO: дубль
                    Console.WriteLine("Choose gender of person." +
                    "Enter 1 for male or 2 for female");
                    var personGender = PersonGender.Male;
                    //TODO: goto o_O
                    Gender:
                    try
                    {
                        int gender = Convert.ToInt32(Console.ReadLine());
                        switch (gender)
                        {
                            case 1:
                                personGender = PersonGender.Male;
                                defaultPerson.Gender = personGender;
                                validGender = true;
                                break;
                            case 2:
                                personGender = PersonGender.Female;
                                defaultPerson.Gender = personGender;
                                validGender = true;
                                break;
                            default:
                                Console.WriteLine("Enter 1 or 2!!!");
                                goto Gender;
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Try again!");
                        goto Gender;
                    }
                }
            }
            return defaultPerson;
        }

        /// <summary>
        /// Inter person from console
        /// </summary>
        /// <returns>Instance person</returns>
        static Person ReadPerson1()
        {
            var defaultPerson = new Person();
            var actionsTupleList = new List<(Action Action, string Message)>
            {
                (
                    () => { defaultPerson.Name = Console.ReadLine(); },
                    "Enter name of person:"
                ),
                (
                    () =>
                    {
                        defaultPerson.Surname = Console.ReadLine();
                    },
                    "Enter surname of person:"),
                (
                    () =>
                    {
                        defaultPerson.Age = Convert.ToInt32(Console.ReadLine());
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
                                Console.WriteLine("Enter 1 or 2!!!");
                                break;
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
