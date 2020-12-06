using ClassLibrary;
using System;

namespace TimeAndTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, You can create new Time or TimePeriod object, call an action:");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Create Time obj");
                Console.WriteLine("2. Create TimePeriod obj");
                Console.WriteLine("3. Exit");
                string choiceInMainMenu = Console.ReadLine();
                choiceInMainMenu.Trim();
                switch (choiceInMainMenu)
                {
                    case "1":
                        CreateTimeObj();
                        break;
                    case "2":
                        CreateTimePeriodObj();
                        break;
                    case "3":
                        flag = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                    
                }
            }
            Console.WriteLine("Shutting down");

        }
        private static void CreateTimeObj()
        {
            AvailableActionsInCreateTimeObj();
        }
        private static void CreateTimePeriodObj()
        {

        }
        private static void AvailableActionsInCreateTimeObj()
        {
            Console.WriteLine("Available constructors:");
            Console.WriteLine("1. Empty (default): Time is 00:00:00");
            Console.WriteLine("2. One argument corresponding to hours)");
            Console.WriteLine("3. Two arguments corresponding to hours and minutes");
            Console.WriteLine("4. Three arguments corresponding to hours, minutes and seconds");
            Console.WriteLine("5. String input in pattern HH:MM:SS");
            Console.WriteLine("6. Exit to main menu");
            Console.WriteLine("Choose option, remember to input values within correct range, otherwise exception will be thrown and application will shut down");
        }

    }
}
