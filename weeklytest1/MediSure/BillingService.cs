using System;

class BillingService
{
    public static PatientBill? LastBill = null;
    public static bool HasLastBill = false;

    public static void CreateNewBill()
    {
        PatientBill bill = new PatientBill();

        Console.Write("Enter Bill Id: ");
        bill.BillId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bill.BillId))
        {
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string ins = Console.ReadLine() ?? "N";
        bill.HasInsurance = ins.ToUpper() == "Y";

        Console.Write("Enter Consultation Fee: ");
        decimal consultationFee = decimal.Parse(Console.ReadLine() ?? "0");
        if (consultationFee <= 0)
        {
            Console.WriteLine("Consultation fee must be greater than zero.");
            return;
        }
        bill.ConsultationFee = consultationFee;

        Console.Write("Enter Lab Charges: ");
        bill.LabCharges = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = decimal.Parse(Console.ReadLine() ?? "0");

        // Calculations (using .Value safely)
        bill.GrossAmount =
            bill.ConsultationFee.Value +
            bill.LabCharges.Value +
            bill.MedicineCharges.Value;

        if (bill.HasInsurance == true)
            bill.DiscountAmount = bill.GrossAmount * 0.10m;
        else
            bill.DiscountAmount = 0;

        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

        LastBill = bill;
        HasLastBill = true;

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
    }

    public static void ViewLastBill()
    {
        if (!HasLastBill || LastBill == null)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        Console.WriteLine("\nLast Bill");
        Console.WriteLine("Bill Id: " + LastBill.BillId);
        Console.WriteLine("Patient Name: " + LastBill.PatientName);
        Console.WriteLine("Insured: " + (LastBill.HasInsurance == true ? "Yes" : "No"));
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
    }

    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}
