using System;
using QuickMart;
namespace QuickMart{
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nQuickMart Traders");
            Console.WriteLine("1. Create New Transaction");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ProfitService.CreateTransaction();
                    break;

                case 2:
                    ProfitService.ViewTransaction();
                    break;

                case 3:
                    ProfitService.Recalculate();
                    break;

                case 4:
                    Console.WriteLine("Thank you. Application closed normally.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
}
