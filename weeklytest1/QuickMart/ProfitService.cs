using System;

class ProfitService
{
    public static SaleTransaction? LastTransaction = null;
    public static bool HasLastTransaction = false;

    public static void CreateTransaction()
    {
        SaleTransaction t = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        t.InvoiceNo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(t.InvoiceNo))
        {
            Console.WriteLine("Invoice No cannot be empty.");
            return;
        }

        Console.Write("Enter Customer Name: ");
        t.CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        t.ItemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        int qty = int.Parse(Console.ReadLine() ?? "0");
        if (qty <= 0)
        {
            Console.WriteLine("Quantity must be greater than zero.");
            return;
        }
        t.Quantity = qty;

        Console.Write("Enter Purchase Amount (total): ");
        decimal purchase = decimal.Parse(Console.ReadLine() ?? "0");
        if (purchase <= 0)
        {
            Console.WriteLine("Purchase amount must be greater than zero.");
            return;
        }
        t.PurchaseAmount = purchase;

        Console.Write("Enter Selling Amount (total): ");
        decimal selling = decimal.Parse(Console.ReadLine() ?? "0");
        if (selling < 0)
        {
            Console.WriteLine("Selling amount cannot be negative.");
            return;
        }
        t.SellingAmount = selling;

        CalculateProfitLoss(t);

        LastTransaction = t;
        HasLastTransaction = true;

        Console.WriteLine("\nTransaction saved successfully.");
        PrintResult(t);
    }

    public static void CalculateProfitLoss(SaleTransaction t)
    {
        if (t.SellingAmount!.Value > t.PurchaseAmount!.Value)
        {
            t.ProfitOrLossStatus = "PROFIT";
            t.ProfitOrLossAmount =
                t.SellingAmount.Value - t.PurchaseAmount.Value;
        }
        else if (t.SellingAmount.Value < t.PurchaseAmount.Value)
        {
            t.ProfitOrLossStatus = "LOSS";
            t.ProfitOrLossAmount =
                t.PurchaseAmount.Value - t.SellingAmount.Value;
        }
        else
        {
            t.ProfitOrLossStatus = "BREAK-EVEN";
            t.ProfitOrLossAmount = 0;
        }

        t.ProfitMarginPercent =
            (t.ProfitOrLossAmount.Value / t.PurchaseAmount.Value) * 100;
    }

    public static void ViewTransaction()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("\n----------- Last Transaction -----------");
        Console.WriteLine("Invoice No: " + LastTransaction.InvoiceNo);
        Console.WriteLine("Customer Name: " + LastTransaction.CustomerName);
        Console.WriteLine("Item Name: " + LastTransaction.ItemName);
        Console.WriteLine("Quantity: " + LastTransaction.Quantity);
        Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
    }

    public static void Recalculate()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        CalculateProfitLoss(LastTransaction);
        PrintResult(LastTransaction);
    }

    static void PrintResult(SaleTransaction t)
    {
        Console.WriteLine("Status: " + t.ProfitOrLossStatus);
        Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
    }
}
