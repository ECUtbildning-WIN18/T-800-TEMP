using System;
using System.Collections.Generic;
using System.Text;

namespace T800.Domain
{
    class Person
    {
        public string Name { get; }
        public string CurrentStatus { get; }

        public Person(string typeName, string currentStatus)
        {
            Name = typeName;
            CurrentStatus = currentStatus;
        }
    }
}
