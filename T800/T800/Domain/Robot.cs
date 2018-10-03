using System;
using System.Collections.Generic;
using System.Text;

namespace T800.Domain
{
    class Robot
    {
        public string Name      { get; set; }
        public int ID           { get; set; }
        public int Health       { get; set; }
        public bool IsAlive     { get; set; }
        public int Head         { get; set; }
        public int Torso        { get; set; }
        public int LArm         { get; set; }
        public int RArm         { get; set; }
        public int LLeg         { get; set; }
        public int RLeg         { get; set; }
        public int Ammo         { get; set; }
        public int Fuel         { get; set; }
        public int Core         { get; set; }
        public int Temperature  { get; set; }

        public List<Person> KillList;

        public Robot(string name, int id, bool isAlive)
        {
            Name = name;
            ID = id;
            IsAlive = isAlive;

            Fuel = 100;
            Ammo = 1000;

            Health = 100;
            Head = 100;
            Core = 100;
            Torso = 10;
            LArm = 10; RArm = 10;
            LLeg = 10; RLeg = 10;

            Temperature = 40;
        }
    }
}
