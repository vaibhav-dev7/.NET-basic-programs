using System;

// Delegate for payment processing
public delegate void PaymentDelegate(double amount);

public class PaymentGateway
{
    public void PayUsingCreditCard(double amount)
    {
        Console.WriteLine($"Payment of Rs.{amount} done using Credit Card.");
    }

    public void PayUsingUPI(double amount)
    {
        Console.WriteLine($"Payment of Rs.{amount} done using UPI.");
    }

    public void PayUsingNetBanking(double amount)
    {
        Console.WriteLine($"Payment of Rs.{amount} done using NetBanking.");
    }

    public void ProcessPayment(PaymentDelegate paymentMethod, double amount)
    {
        paymentMethod(amount);
    }
}

public class Program
{
    public static void Main()
    {
        PaymentGateway gateway = new PaymentGateway();

        PaymentDelegate method;

        Console.WriteLine("Choose Payment Method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. UPI");
        Console.WriteLine("3. NetBanking");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                method = gateway.PayUsingCreditCard;
                break;
            case 2:
                method = gateway.PayUsingUPI;
                break;
            case 3:
                method = gateway.PayUsingNetBanking;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        gateway.ProcessPayment(method, 2000);
    }
}