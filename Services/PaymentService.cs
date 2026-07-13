namespace PaymentsAPI.Services;

public class PaymentService
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment: {amount}");

        return Random.Shared.Next(1, 10) > 3;
    }
}
