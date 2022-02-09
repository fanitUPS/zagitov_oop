﻿using System;
using System.Linq;

namespace ModelLab1Classes
{
    /// <summary>
    /// Class list of persons
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Array of person
        /// </summary>
        private Person[] _personArray = new Person[0];
        
        /// <summary>
        /// Length of PersonList
        /// </summary>
        public int Length => _personArray.Length;

        /// <summary>
        /// Add new instanse in PersonList
        /// </summary>
        /// <param name="person">Instanse of added person</param>
        public void Add(Person person)
        {
            int countArray = _personArray.Length;
            Array.Resize(ref _personArray, countArray + 1);
            int endIndexArray = countArray;
            _personArray[endIndexArray] = person;
        }

        //TODO: naming
        /// <summary>
        /// Delete last added person in PersonList
        /// </summary>
        public void Delete()
        {
            int countArray = _personArray.Length;
            Array.Resize(ref _personArray, countArray - 1);
        }

        /// <summary>
        /// Delete person in PersonList by index
        /// </summary>
        /// <param name="index">Index of deleted person</param>
        public void DeleteIndex(int index)
        {
            _personArray = _personArray.Where((_, indexArray) =>
                indexArray != index).ToArray();
        }

        //TODO: naming by-
        /// <summary>
        /// Search element in PersonList by index
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element of PersonList</returns>
        public Person SearchIndex(int index)
        {
            return _personArray[index];
        }

        //TODO: naming by-
        /// <summary>
        /// Search index of element by name
        /// </summary>
        /// <param name="person">Instanse Person</param>
        /// <returns>Index of element</returns>
        public int SearchName(Person person)
        {
            return Array.IndexOf(_personArray, person);
        }

        /// <summary>
        /// Remove all element from PersonList
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref _personArray, 0);
        }

        /// <summary>
        /// Show in console all elements in PersonList
        /// </summary>
        public string ListInfo()
        {
            string infoList = "";
            foreach (var person in _personArray)
            {
                 infoList = infoList + "\n" + person.Info();
            }
            return infoList;
        }
    }
}
