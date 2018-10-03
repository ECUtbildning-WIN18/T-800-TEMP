using System;
namespace T800.Domain
{
    public class Activation
    {
        public Activation()
        {
            Console.WriteLine("Do you want to activate or deactivate the robot? 1/2");
            string robot = Console.ReadLine();
            int nr = Convert.ToInt32(robot);
            switch (nr)
            {
                case 1:
                    Console.WriteLine("Robot is activated");
                    break;

                case 2:
                    Console.WriteLine("Robot is deactivated");
                    break;

                default:
                    Console.WriteLine("Read the instructions again.");
                    break;
            }
            if (robot == "1")
            {
                Console.WriteLine("System is warming up, soon I'll be ready to continue on my execution list!");
            }
            else if (robot == "2")
            {
                Console.WriteLine("I'm going into sleepmode. Allow me to take you back to the main menu.");
            }
            //Console.WriteLine("Do you want to activate the robot? y/n");
            //string robot = Console.ReadLine();


            //if (robot == "Yes" || robot == "y")
            //{
            //    Console.WriteLine("You have activated the robot.");
            //}
            //else if (robot == "No" || robot == "n")
            //{
            //    Console.WriteLine("Do you want to deactivate the robot? y/n");
            //}
            //if (robot == "Yes" || robot == "y")
            //{
            //    Console.WriteLine("You have deactivated the robot.")
            //;
            //}
            //else if (robot == "No" || robot == "n")
            //    {
            //    Console.WriteLine("You chose not to deactivate the robot, you will now return to the main menu");
            //    }
            //Console.ReadLine();
        }
    }
}
