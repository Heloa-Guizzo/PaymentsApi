using MassTransit;
using PaymentsAPI.Services;
using Shared.Events;

namespace PaymentsAPI.Consumers;

public class OrderPlacedConsumer : IConsumer<OrderPlacedEvent>
{
    private readonly PaymentService _paymentService;
    private readonly IPublishEndpoint _publish;

    public OrderPlacedConsumer(
        PaymentService paymentService,
        IPublishEndpoint publish)
    {
        _paymentService = paymentService;
        _publish = publish;
    }

    public async Task Consume(
        ConsumeContext<OrderPlacedEvent> context)
    {

        Console.WriteLine(
            $"[PaymentsAPI] OrderPlacedEvent received");

        Console.WriteLine(
            $"[PaymentsAPI] Processing payment | UserId: {context.Message.UserId} | GameId: {context.Message.GameId} | Price: {context.Message.Price}");

        var approved = context.Message.Price <= 100;

        Console.WriteLine(
            approved
                ? "[PaymentsAPI] Payment approved"
                : "[PaymentsAPI] Payment declined");

        await _publish.Publish(
            new PaymentProcessedEvent(
                context.Message.UserId,
                context.Message.GameId,
                approved));

        Console.WriteLine(
            "[PaymentsAPI] PaymentProcessedEvent published");
    }

}