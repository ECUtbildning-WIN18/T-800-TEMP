using System;
namespace T800.Domain
{
    class Details
    {
        static Robot Killer  { get; set; }
        static Execute Plans { get; set; }

        static readonly int _length = 35;
        static readonly int _height = 15;
        static int xCoord;
        static int yCoord;

        public Details(Robot killer, Execute plans)
        {
            Console.SetCursorPosition(_length, 0);
            xCoord = Console.CursorLeft;
            yCoord = Console.CursorTop;

            Killer = killer;
            Plans = plans;
        }

        public void DrawSideBox()
        {
            for (int x = 0 + 35; x < _length + 35; x++) //TOP
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
            for (int x = 0 + 35; x <= _length + 35; x++) //BOTTOM
            {
                WriteAt("#", xCoord + x, yCoord + _height);
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

        static void ClearInsideSideBox()
        {
            for (int x = 1 + 35; x < _length + 35; x++)
            {
                for (int y = 1; y < _height; y++)
                {
                    WriteAt(" ", x, y);
                }
            }
        }
    }
}
