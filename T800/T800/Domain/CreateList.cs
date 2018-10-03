using System;
using System.Collections.Generic;

namespace T800.Domain
{
    class CreateList : Person
    {
        public static List<Person> PersonList { get; set; } 

        public CreateList(string typeName) : base(typeName, true)
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

        public static void AddPerson(string typeName)               // typeName = Console.ReadLine();
        {                                                           //Had this on program.cs
            Console.WriteLine("Who's the target?");
            Person p = new Person(typeName, true);
            PersonList.Add(p);
        }
    }
}
