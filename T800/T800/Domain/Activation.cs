using System;

namespace T800.Domain
{
    public class Activation
    {
        public Activation(int xCoord, int yCoord)
        {
            WriteAtJustified("Do you want to activate or deactivate the robot?", 2);
            WriteAtJustified("1-yes 2-no", 3);
            ConsoleKey r = Console.ReadKey().Key;
            switch (r)
            {
                case ConsoleKey.D1:
                    WriteAtJustified("Robot is activated", 4);
                    break;

                case ConsoleKey.D2:
                    WriteAtJustified("Robot is deactivated", 4);
                    break;

                default:
                    WriteAtJustified("Read the instructions again", 3);
                    break;
            }
            if (r == ConsoleKey.D1)
            {
                WriteAtJustified("System is warming up", 7);
                WriteAtJustified("Soon I'll be ready to", 8);
                WriteAtJustified("continue on my execution list!", 9);
                WriteAtJustified("Press return to go back", 11);
                Console.ReadLine();
                ClearInsideSide();
            }
            else if (r == ConsoleKey.D2)
            {
                WriteAtJustified("I'm going into sleepmode.", 7);
                WriteAtJustified("Allow me to take you", 8);
                WriteAtJustified("back to the main menu.", 9);
                WriteAtJustified("Press return to go back", 11);
                Console.ReadLine();
                ClearInsideSide();
            }

            void WriteAt(string s, int x, int y)
            {
                Console.SetCursorPosition(xCoord + x, yCoord + y);
                Console.Write(s);
            }

            void WriteAtJustified(string s, int y)
            {
                int justifiedX = Convert.ToInt32(Math.Floor((double)(50 - s.Length) / 2));
                Console.SetCursorPosition(xCoord + justifiedX, yCoord + y);
                Console.Write(s);
            }

            void ClearInsideSide()
            {
                for (int x = 1; x < 50; x++)
                {
                    for (int y = 1; y < 15; y++)
                    {
                        WriteAt(" ", x + 50, y);
                    }
                }
            }
        }
    }
}
