using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace T800
{
    class Program
    {
        public static Domain.CreateList KillList;
        public static Domain.Robot BigDickBoi9000;

        static void Main(string[] args)
        {
            KillList = new Domain.CreateList();
            BigDickBoi9000 = new Domain.Robot("omg im a robot", 420691337, true);

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

        public static int xCoord, yCoord, y;

        public static bool DrawerOut, SideOut, Arrows;
        static readonly int _length = 50; //These 2 values control the size of the box.
        static readonly int _height = 15; //Changing these values resizes it respective of x and y

        public static String Username { get; set; }
        public static String Password { get; set; }

        public static bool Armed;

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
            while (choice != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, 16);
                choice = Console.ReadKey().Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        CreateList();
                        break;
                    case ConsoleKey.D2:
                        UploadList();
                        break;
                    case ConsoleKey.D3:
                        Activate();
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        SelfD();
                        break;
                    case ConsoleKey.Escape:
                        PreLoginMenu();
                        break;
                }
            }
        }

        public static void DrawMenu(int menu)
        {
            y = 0;
            switch(menu)
            {
                case 1: //PRE-LOGIN
                    ClearInside();
                    for (int x = 0; x < _length; x++) 
                    {
                        WriteAt("#", xCoord + x, yCoord); //TOP 
                        Thread.Sleep(1);
                        if (y <= _height) 
                        {
                            WriteAt("#", xCoord + _length, yCoord + x); //RIGHT
                            WriteAt("#", xCoord, yCoord + x); //LEFT
                            Thread.Sleep(1);
                            y++;
                        }
                        WriteAt("#", xCoord + x, yCoord + _height); //BOTTOM
                        Thread.Sleep(1);
                    }
                    for (int x = 0; x < _length; x++) //SEPARATOR AT LINE 6
                    {
                        WriteAt("#", xCoord + x, yCoord + 5);
                        Thread.Sleep(1);
                    }
                    WriteAtJustified("TERMINATOR TERMINAL V1.0", 2);
                    WriteAtJustified("You pick 'em, we kill'em!", 3);
                    WriteAtJustified("PLEASE LOG IN TO CONTINUE", 6);

                    WriteAtJustified("1. LOG IN", 10);
                    WriteAtJustified("ESC: EXIT", 12);
                    break;

                case 2: //LOGIN
                    ClearInside();
                    for (int x = 0; x < _length; x++)
                    {
                        WriteAt("#", xCoord + x, yCoord); //TOP 
                        Thread.Sleep(1);
                        if (y <= _height)
                        {
                            WriteAt("#", xCoord + _length, yCoord + x); //RIGHT
                            WriteAt("#", xCoord, yCoord + x); //LEFT
                            Thread.Sleep(1);
                            y++;
                        }
                        WriteAt("#", xCoord + x, yCoord + _height); //BOTTOM
                        Thread.Sleep(1);
                    }
                    for (int x = 0; x < _length; x++) //SEPARATOR AT LINE 6
                    {
                        WriteAt("#", xCoord + x, yCoord + 5);
                        Thread.Sleep(1);
                    }
                    WriteAtJustified("TERMINATOR TERMINAL V1.0", 2);
                    WriteAtJustified("You pick 'em, we kill'em!", 3);
                    WriteAtJustified("PLEASE LOG IN TO CONTINUE", 6);
                    WriteAt("USERNAME: ", 4, 10);
                    WriteAt("PASSWORD: ", 4, 12);
                    WriteAtJustified("ESC: BACK", 14); //This doesnt actually work, but maybe i should leave it in. Maybe teacher wont notice :thinking:
                    break;

                case 3: //LOGGED IN
                    ClearInside();
                    for (int x = 0; x < _length; x++)
                    {
                        WriteAt("#", xCoord + x, yCoord); //TOP 
                        Thread.Sleep(1);
                        if (y <= _height)
                        {
                            WriteAt("#", xCoord + _length, yCoord + x); //RIGHT
                            WriteAt("#", xCoord, yCoord + x); //LEFT
                            Thread.Sleep(1);
                            y++;
                        }
                        WriteAt("#", xCoord + x, yCoord + _height); //BOTTOM
                        Thread.Sleep(1);
                    }
                    for (int x = 0; x < _length; x++) //SEPARATOR AT LINE 6
                    {
                        WriteAt("#", xCoord + x, yCoord + 5);
                        Thread.Sleep(1);
                    }
                    WriteAtJustified("TERMINATOR TERMINAL V1.0", 2);
                    WriteAtJustified("You pick 'em, we kill'em!", 3);
                    WriteAtJustified("LOGGED IN AS: " + Username, 6);

                    WriteAt("1. Add person to Kill List", 4, 8);
                    WriteAt("2. Upload Kill List to current robot", 4, 9);
                    WriteAt("3. Activate/Deactivate current robot", 4, 10);
                    WriteAt("4. See details of current robot activity", 4, 11);
                    WriteAt("5. Self destruct robot **WARNING**", 4, 12);
                    WriteAtJustified("ESC: LOGOUT", 14);
                    break;
            }
        }

        public static void CreateList()
        {
            ConsoleKey listChoice = ConsoleKey.Spacebar;

            SideBox();
            AtnArrows();
            WriteAtJustifiedSide("KILL LIST CREATOR V1", 3);
            WriteAtJustifiedSide("Enter the name of a person you want to add", 5);
            while (listChoice != ConsoleKey.Escape)
            {
                listChoice = ConsoleKey.D1;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        ClearInsideSide();
                        WriteAtJustifiedSide("KILL LIST CREATOR V1", 3);
                        WriteAtJustifiedSide("Enter the name of a person you want to add", 5);
                        WriteAt("->", _length + 6, 6);
                        Console.SetCursorPosition(_length + 8, 6);
                        string targetToAdd = Console.ReadLine();
                        if (targetToAdd == "") 
                        {
                            listChoice = ConsoleKey.Escape;
                            break;
                        }
                        Program.KillList.AddPerson(targetToAdd);
                        WriteAtJustifiedSide("Person " + targetToAdd + " added", 10);
                        WriteAtJustifiedSide("Press return to go back", 11);
                        Console.ReadLine();
                        listChoice = ConsoleKey.Escape;
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            }
            ClearInsideSide();
            SideBox();
            AtnArrows();
        }

        public static void UploadList()
        {
            Domain.UploadList ul = new Domain.UploadList(Program.KillList.PersonList, Program.BigDickBoi9000);
            Task t = Task.Factory.StartNew(() =>
           {
                UnderBox();
                WriteAtJustified("Kill List updated", 17);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                ClearInsideDrawer();
                UnderBox();
           });
        }

        public static void Activate()
        {
            ClearInsideSide();
            SideBox();
            AtnArrows();
            Domain.Activation a = new Domain.Activation(50, 0);
            Armed = true;
            ClearInsideSide();
            SideBox();
            AtnArrows();
        }

        public static void SelfD()
        {
            ConsoleKey listChoice = ConsoleKey.Spacebar;

            SideBox();
            AtnArrows();
            WriteAtJustifiedSide("!! WARNING !!", 3);
            WriteAtJustifiedSide("ARE YOU SURE YOU WANT TO", 5);
            WriteAtJustifiedSide(">> SELF DESTRUCT <<", 6);
            WriteAtJustifiedSide("THE ROBOT", 7);
            WriteAtJustifiedSide("1-yes   2-no", 7);

            listChoice = Console.ReadKey().Key;
            switch (listChoice)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Domain.Selfdestruct sd = new Domain.Selfdestruct();
                    sd.Selfdestruction();
                    Console.WriteLine("Self destruction completed.. \n" +
                                      "Press return to reboot..");
                    Console.ReadLine();
                    PreLoginMenu();
                    break;
                case ConsoleKey.Escape:
                    break;
            }
            ClearInsideSide();
            SideBox();
            AtnArrows();
        }

        static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(xCoord + x, yCoord + y);
            Console.Write(s);
        }

        static void WriteAtJustified(string s, int y)
        {
            int justifiedX = Convert.ToInt32(Math.Floor((double) (_length - s.Length) / 2));
            Console.SetCursorPosition(xCoord + justifiedX, yCoord + y);
            Console.Write(s);
        }

        static void WriteAtJustifiedSide(string s, int y)
        {
            int justifiedX = Convert.ToInt32(Math.Floor((double)(_length - s.Length) / 2));
            Console.SetCursorPosition(_length + justifiedX, yCoord + y);
            Console.Write(s);
        }

        static void ClearCurrentConsoleLine(int repX, int repY) //OVERLOADS TO MANUALLY REPOSITION THE CURSOR
        {
            Console.SetCursorPosition(repX, repY);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void AtnArrows()
        {
            if (!Arrows)
            {
                for (int x = 0; x < 7; x++)
                {
                    WriteAt("->", 49, 7 + x);
                }
                Arrows = true;
            } else
            {
                for (int x = 0; x < 7; x++)
                {
                    WriteAt(" #", 49, 7 + x);
                }
                Arrows = false;
            }
        }

        static void SideBox()
        {
            if (!SideOut)
            {
                for (int length = 1; length <= _length; length++)
                {
                    WriteAt("#", _length + length, 0);
                    WriteAt("#", _length + length, _height);
                    if (length == _length)
                    {
                        for (int height = 0; height <= _height; height++)
                        {
                            WriteAt("#", length + _length, height);
                            Thread.Sleep(2);
                        }
                    }
                    Thread.Sleep(4);
                }
                SideOut = true;
            } else
            {
                for (int length = _length * 2; length > _length; length--)
                {
                    if (length == _length * 2)
                    {
                        for (int height = 0; height <= _height; height++)
                        {
                            WriteAt(" ", _length * 2, height);
                            Thread.Sleep(2);
                        }
                    }
                    WriteAt(" ", length, 0);
                    WriteAt(" ", length, _height);
                    Thread.Sleep(4);
                }
                SideOut = false;
            }
        }

        static void UnderBox()
        {
            if (!DrawerOut)
            {
                for (int height = 0; height < 6; height++)
                {
                    //Emulate a sliding-box animation
                    WriteAt("#", 0, _height + height);
                    WriteAt("#", _length, _height + height);
                    for (int x = 1; x < _length; x++) 
                    {
                        WriteAt("#", _length - x, _height + height);
                        if (height != 5 && height != 0)
                        {
                            WriteAt(" ", _length - x, _height + height);
                        }

                    }
                    Thread.Sleep(8);
                }
                DrawerOut = true;
            } else
            {
                for (int height = 5; height > 0; height--)
                {
                    //Emulate a sliding-box animation
                    WriteAt(" ", 0, _height + height);
                    WriteAt(" ", _length, _height + height);
                    if (height != 0)
                    {
                        for (int x = 0; x < _length + 1; x++)
                        {
                            WriteAt(" ", _length - x, _height + height);
                        }
                    }
                    Thread.Sleep(8);
                }
                DrawerOut = false;
            }
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

        static void ClearInsideSide()
        {
            for (int x = 1; x < _length; x++)
            {
                for (int y = 1; y < _height; y++)
                {
                    WriteAt(" ", x + _length, y);
                }
            }
        }

        static void ClearInsideDrawer()
        {
            for (int x = 1; x < _height; x++)
            {
                for (int y = 1; y < _length; y++)
                {
                    WriteAt(" ", x, y + _height);
                }
            }
        }
    }
}
