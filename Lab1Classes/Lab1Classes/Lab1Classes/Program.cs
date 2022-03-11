using ModelLab1Classes;
using System;

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
            var rnd = new Random();

            var personList = new PersonList();

            for (int i = 0; i < 8; i++)
            {
                if (rnd.Next(2) == 0)
                {
                    personList.Add(Adult.GetRandomPerson(rnd));
                }
                else
                {
                    personList.Add(Child.GetRandomChild(rnd));
                }
            }     

            OutputInConsole(personList);

            //TODO:
            var person = personList.SearchByIndex(3);
            person.Holydays();

            Console.ReadKey();
        }
        
        /// <summary>
        /// Output in console all elements in PersonList
        /// </summary>
        /// <param name="personList">Instance PersonList</param>
        private static void OutputInConsole(PersonList personList)
        {
            Console.WriteLine(personList.ListInfo());
        }
    }
}
