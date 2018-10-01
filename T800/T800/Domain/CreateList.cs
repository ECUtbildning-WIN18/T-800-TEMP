using System;
using System.Collections.Generic;

namespace T800.Domain
{
    class CreateList : Person
    {
        public static List<Person> PersonList { get; set; } 

        public CreateList(string typeName) : base(typeName, "Alive")
        {
            PersonList = new List<Person>();
            Person p = new Person(typeName, "Alive");
            AddPerson(p);
        }

        public void PrintStatus()
        {
            foreach (var person in PersonList)
            {
                Console.WriteLine($"{person.Name}, Status: {person.CurrentStatus}");
            }
        }

        public static void AddPerson(Person typeName)               // typeName = Console.ReadLine();
        {                                                           //Had this on program.cs
            Console.WriteLine("Who's the target?");
            PersonList.Add(typeName);
        }
    }
}
