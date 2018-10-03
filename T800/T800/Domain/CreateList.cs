using System;
using System.Collections.Generic;

namespace T800.Domain
{
    class CreateList
    {
        public List<Person> PersonList { get; set; } 

        public CreateList()
        {
            PersonList = new List<Person>();
        }

        public void PrintStatus()
        {
            foreach (var person in PersonList)
            {
                Console.WriteLine($"{person.Name}, Status: {person.IsAlive}");
            }
        }

        public void AddPerson(string typeName)               // typeName = Console.ReadLine();
        {                                                           //Had this on program.cs
            Person p = new Person(typeName, true);
            PersonList.Add(p);
        }
    }
}
