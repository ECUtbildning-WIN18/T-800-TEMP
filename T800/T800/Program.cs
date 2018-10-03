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
       
    }
}
