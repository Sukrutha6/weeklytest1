using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMediSure Clinic Billing");
            Console.WriteLine("1. Create New Bill");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
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
                    BillingService.CreateNewBill();
                    break;

                case 2:
                    BillingService.ViewLastBill();
                    break;

                case 3:
                    BillingService.ClearLastBill();
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
