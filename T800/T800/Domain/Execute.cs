using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace T800.Domain
{
    class Execute
    {
        public static Robot Killer { get; set; }

        static readonly int _length = 35;
        static readonly int _height = 15;
        static int xCoord;
        static int yCoord;

        public Execute(Robot killer)
        {
            Console.SetCursorPosition(_length, 0);
            xCoord = Console.CursorLeft;
            yCoord = Console.CursorTop;

            Killer = killer;
        }

        public void StartKilling()
        {
            foreach (Person p in Killer.KillList)
            {
                Search(p);
                Fight(p);

            }
        }

        public void Search(Person p)
        {
            Random r = new Random();

            if (p.IsAlive)
            {
                CurrentActivity(1, p);

                CurrentActivity(2, p);

                bool found = false;
                while (!found)
                {
                    int randomWaitingTime = r.Next(1, 9);
                    Thread.Sleep(TimeSpan.FromSeconds(randomWaitingTime));
                    if (new Func<bool>(() =>
                    {
                        int fiddyfiddy = r.Next(1, 2);
                        if (fiddyfiddy == 1) return true;
                        else return false;
                    })())
                    {
                        CurrentActivity(21, p);
                        found = true;
                    }
                    else CurrentActivity(22, p);
                }
            }
        }

        public void Fight(Person p)
        {
            Random r = new Random();
            bool escaped = false;
            Func<bool> theyGotAway = () =>
            {
                int i = r.Next(1, 100);
                if (i == 100)
                    return true;
                else return false;
            };
            CurrentActivity(31, p);
            while (p.IsAlive)
            {
                escaped = theyGotAway();
                CurrentActivity(32, p);  
                int shots = r.Next(1, 50);
                Killer.Ammo -= shots;
                p.Health -= r.Next(1, 100);
                if (escaped)
                {
                    CurrentActivity(334, p);
                    Search(p);
                    break;
                }
                if (p.Health == 0)
                {
                    CurrentActivity(333, p);
                    p.IsAlive = false;
                    break;
                }
                if (p.Health > 75 && p.Health <= 100)
                {
                    CurrentActivity(33, p);
                }
                else if (p.Health >= 50 && p.Health < 75)
                {
                    CurrentActivity(34, p);
                }
                else if (p.Health >= 25 && p.Health < 50)
                {
                    CurrentActivity(35, p);
                }
                else if (p.Health >= 1 && p.Health < 25)
                {
                    CurrentActivity(36, p);
                }
                else if (p.Health == 0 || p.Health < 0)
                {
                    p.Health = 0;
                    CurrentActivity(37, p);
                    p.IsAlive = false;
                }
            }
        }

        public void Maintenance()
        {

        }

        public void CurrentActivity(int stage, Person p)
        {
            switch(stage)
            {
                case 1:
                    Console.WriteLine("{0} is alive and is being located", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 2:
                    Console.WriteLine("{0} is being hunted.. Searching..", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 21:
                    Console.WriteLine("Target {0} has been found! Engaging!", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 22:
                    Console.WriteLine("Couldn't find {0} this time, seaching more..", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 31:
                    Console.WriteLine("Engaging target {0} in combat..", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 32:
                    Console.WriteLine("Discharging lethal force at target..", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 33:
                    Console.WriteLine("Target still seems healthy, continuing to engage", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 34:
                    Console.WriteLine("Target is injured, continuing to engage", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 35:
                    Console.WriteLine("Target seems heavily injured, finalizing orders..", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 36:
                    Console.WriteLine("Target is on their last breath.. Say goodnight.", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 37:
                    Console.WriteLine("Target eliminated, reporting combat statistics", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 333:
                    Console.WriteLine("BOOM HEADSHOT! Target Annihilated! (This is a 1/100 chance, 1-shot kill)", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
                case 334:
                    Console.WriteLine("Target {0} has escaped, for now - will return to searching! (This is a 1/100 chance, target escaped)", p.Name);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    break;
            }
        }

        public void UpdateStatus()
        {

        }
    }
}
