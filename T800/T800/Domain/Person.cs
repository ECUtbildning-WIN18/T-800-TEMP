using System;
using System.Collections.Generic;
using System.Text;

namespace T800.Domain
{
    class Person
    {
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public int Health { get; set; }

        public Person(string typeName, bool isAlive)
        {
            Name = typeName;
            IsAlive = isAlive;
            Health = 100;
        }
    }
}
