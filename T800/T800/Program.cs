using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace T800
{
    class Program
    {
        public static Domain.Robot KillingMachine9000;
        public static Domain.Execute Plans;
        public static Domain.Details Details;

        public static List<Person> HitList;

        static void Main(string[] args)
        {
            #region Debugging region
            HitList = new List<Person>();
            Person one = new Person("Ryan");
            Person two = new Person("Paula");
            HitList.Add(one);
            HitList.Add(two);
            #endregion

            Console.CursorVisible = false;
            Menu m = new Menu();
            /*
             * 1. login
             * 2. exit
             * * \/ Logged in
             * 1. Create list
             * 2. Upload list
             * 3. Activate/Deactivate
             * 4. Status
             * 5. Self-destruct
             * 0. Exit
             */
        }
    }

    public class Menu
    {
        //x = left, y = top
        //X GROWS LEFT TO RIGHT
        //Y GROWS TOP TO BOTTOM
        //We first clear the console to get a base position of the cursor which then allows us to easily define specific
        //cells of the terminal program being used - this is USUALLY the very top left-most cell in the terminal. The menu
        //is then drawn based on that initial location. This location is our 0,0.
        public static int xCoord, yCoord;

        static readonly int _length = 35;
        static readonly int _height = 15;

        public static String Username { get; set; }
        public static String Password { get; set; }

        public static ConsoleKey choice;

        public Menu()
        {
            xCoord = Console.CursorLeft;
            yCoord = Console.CursorTop;
            Console.Clear();

            PreLoginMenu();
        }

        public static void PreLoginMenu()
        {
            DrawMenu(1);

            choice = Console.ReadKey().Key;
            switch (choice)
            {
                case ConsoleKey.D1:
                    LoginMenu();
                    break;
                case ConsoleKey.Escape:
                    break;
            }
        }

        public static void LoginMenu()
        {
            DrawMenu(2);

            WriteAt("->", 2, 10);
            Console.SetCursorPosition(15, 10);
            Console.CursorVisible = true;
            string username = Console.ReadLine();
            WriteAt("  ", 2, 10);

            WriteAt("->", 2, 12);
            Console.SetCursorPosition(15, 12);
            string password = Console.ReadLine();
            WriteAt("  ", 2, 12);
            Console.CursorVisible = false;

            LoggedInMenu(username, password);
        }

        public static void LoggedInMenu(string username, string password)
        {
            Username = username;
            DrawMenu(3);

            do
            {
                choice = Console.ReadKey().Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        //Create list - Paula
                        //List is created in here, then use the next command to upload it to the robot.
                        //@@@@@@@@@@@@@@@ADAPT THIS CODE FOR PAULAS METHOD
                        break;
                    case ConsoleKey.D2:
                        //Assign list to robot - Paula
                        //Here a list is assigned to the robot and attack plans are generated.
                        //Technically, a class of robot is created here, and then the list created from the previous method is attached.
                        //With the list and robot in place, the execution plans can be generated.
                        //@@@@@@@@@@@@@@@ADAPT THIS CODE FOR PAULAS METHOD
                        Program.KillingMachine9000 = new Domain.Robot("big dick boi 9000", 420691337, true, Program.HitList);
                        Program.Plans = new Domain.Execute(Program.KillingMachine9000);
                        break;
                    case ConsoleKey.D3:
                        //Activate/Deactivate robot - Robin
                        //Here we run the background thread task which executes the kill list provided in methods 1 and 2.
                        //@@@@@@@@@@@@@@@ADAPT THIS CODE FOR ROBINS METHOD
                        Task t = Task.Run(() => Program.Plans.StartKilling());
                        break;
                    case ConsoleKey.D4:
                        Domain.Details d = new Domain.Details(Program.KillingMachine9000, Program.Plans);

                        break;
                    case ConsoleKey.D5:
                        //Self destruct - Anders
                        break;
                    case ConsoleKey.Escape:
                        PreLoginMenu();
                        break;
                }
            }
            while (choice != ConsoleKey.Escape);
        }

        public static void DrawMenu(int menu)
        {
            switch(menu)
            {
                case 1: //PRE-LOGIN
                    ClearInside();
                    for (int x = 0; x < _length; x++) //TOP
                    {
                        WriteAt("#", xCoord + x, yCoord);
                    }
                    for (int x = 0; x < _height; x++) //LEFT
                    {
                        WriteAt("#", xCoord, yCoord + x);
                    }
                    for (int x = 0; x < _height; x++) //RIGHT
                    {
                        WriteAt("#", xCoord + _length, yCoord + x);
                    }
                    for (int x = 0; x <= _length; x++) //BOTTOM
                    {
                        WriteAt("#", xCoord + x, yCoord + _height);
                    }
                    for (int x = 0; x < _length; x++) //SEPARATOR AT LINE 6
                    {
                        WriteAt("#", xCoord + x, yCoord + 5);
                    }
                    WriteAt("TERMINATOR TERMINAL V1.0", 5, 2);
                    WriteAt("You pick 'em, we kill'em!", 5, 3);
                    WriteAt("PLEASE LOG IN TO CONTINUE", 5, 6);

                    WriteAt("1. LOG IN", 12, 10);
                    WriteAt("ESC: EXIT", 12, 12);
                    break;

                case 2: //LOGIN
                    ClearInside();
                    for (int x = 0; x < _length; x++) //TOP
                    {
                        WriteAt("#", xCoord + x, yCoord);
                    }
                    for (int x = 0; x < _height; x++) //LEFT
                    {
                        WriteAt("#", xCoord, yCoord + x);
                    }
                    for (int x = 0; x < _height; x++) //RIGHT
                    {
                        WriteAt("#", xCoord + _length, yCoord + x);
                    }
                    for (int x = 0; x <= _length; x++) //BOTTOM
                    {
                        WriteAt("#", xCoord + x, yCoord + _height);
                    }
                    for (int x = 0; x < _length; x++) //SEPARATOR AT LINE 6
                    {
                        WriteAt("#", xCoord + x, yCoord + 5);
                    }
                    WriteAt("TERMINATOR TERMINAL V1.0", 5, 2);
                    WriteAt("You pick 'em, we kill'em!", 5, 3);
                    WriteAt("PLEASE LOG IN TO CONTINUE", 5, 6);

                    WriteAt("USERNAME: ", 4, 10);
                    WriteAt("PASSWORD: ", 4, 12);
                    WriteAt("ESC: BACK", 15, 14);
                    break;

                case 3: //LOGGED IN
                    ClearInside();
                    for (int x = 0; x < _length; x++) //TOP
                    {
                        WriteAt("#", xCoord + x, yCoord);
                    }
                    for (int x = 0; x < _height; x++) //LEFT
                    {
                        WriteAt("#", xCoord, yCoord + x);
                    }
                    for (int x = 0; x < _height; x++) //RIGHT
                    {
                        WriteAt("#", xCoord + _length, yCoord + x);
                    }
                    for (int x = 0; x <= _length; x++) //BOTTOM
                    {
                        WriteAt("#", xCoord + x, yCoord + _height);
                    }
                    for (int x = 0; x < _length; x++) //SEPARATOR AT LINE 6
                    {
                        WriteAt("#", xCoord + x, yCoord + 5);
                    }
                    WriteAt("TERMINATOR TERMINAL V1.0", 5, 2);
                    WriteAt("You pick 'em, we kill'em!", 5, 3);
                    WriteAt("LOGGED IN AS: ", 5, 6, Username);

                    WriteAt("1. CREATE LIST", 3, 8);
                    WriteAt("2. UPLOAD LIST TO ROBOT", 3, 9);
                    WriteAt("3. ACTIVATE/DEACTIVATE", 3, 10);
                    WriteAt("4. STATUS", 3, 11);
                    WriteAt("5. SELF DESTRUCT", 3, 12);
                    WriteAt("ESC: LOGOUT/BACK", 7, 14);
                    break;
            }
        }

        static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(xCoord + x, yCoord + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static void WriteAt(string s, int x, int y, string name)
        {
            try
            {
                Console.SetCursorPosition(xCoord + x, yCoord + y);
                Console.Write("{0}{1}", s, name);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static void ClearCurrentConsoleLine(int repX, int repY) //OVERLOADS TO MANUALLY REPOSITION THE CURSOR
        {
            Console.SetCursorPosition(repX, repY);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void ClearInside()
        {
            for (int x = 1; x < _length; x++)
            {
                for (int y = 1; y < _height; y++)
                {
                    WriteAt(" ", x, y);
                }
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsAlive  { get; set; }

        public Person(string name)
        {
            Name = name;
            Health = 100;
            IsAlive = true;
        }
    }
}
