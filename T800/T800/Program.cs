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
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Menu m = new Menu();
            /*
             * 1. login
             * 2. exit
             * *
             * 1. Create list
             * 2. Upload list
             * 3. Activate/Deactivate
             * 4. Self-destruct
             * 5. Logout
             * 0. Exit
             */
        }
    }

    public class Menu
<<<<<<< HEAD
    {
        //x = left, y = top
        //X GROWS LEFT TO RIGHT
        //Y GROWS TOP TO BOTTOM
        //We first clear the console to get a base position of the cursor which then allows us to easily define specific
        //cells of the terminal program being used - this is USUALLY the very top left-most cell in the terminal. The menu
        //is then drawn based on that initial location. This location is our 0,0.
=======
    {
        //x = left, y = top
        //X GROWS LEFT TO RIGHT
        //Y GROWS TOP TO BOTTOM
        //We first clear the console to get a base position of the cursor which then allows us to easily define specific
        //cells of the terminal program being used - this is USUALLY the very top left-most cell in the terminal. The menu
        //is then drawn based on that initial location. This location is our 0,0.
>>>>>>> US01_Menu
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
<<<<<<< HEAD
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
=======
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
>>>>>>> US01_Menu
        }

        public static void LoggedInMenu(string username, string password)
        {
<<<<<<< HEAD
            DrawMenu(3);
=======
            DrawMenu(3);
>>>>>>> US01_Menu

            Username = username;

            choice = Console.ReadKey().Key;
            switch (choice)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                case ConsoleKey.D6:
                    break;
                case ConsoleKey.Escape:
                    PreLoginMenu();
                    break;
            }
        }

        public static void DrawMenu(int menu)
        {
<<<<<<< HEAD
            switch (menu)
=======
            switch(menu)
>>>>>>> US01_Menu
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

<<<<<<< HEAD
                    WriteAt("USERNAME: ", 4, 10);
=======
                    WriteAt("USERNAME: ", 4, 10);
>>>>>>> US01_Menu
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
                    WriteAt("LOGGED IN AS: {0}", 5, 6);

                    WriteAt("USERNAME: ", 11, 10);
                    WriteAt("PASSWORD: ", 11, 12);
                    WriteAt("ESC: LOGOUT/BACK", 8, 14);
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
}
