using MassTransit;
using PaymentsAPI.Services;
using Shared.Events;

namespace PaymentsAPI.Consumers;


public class OrderPlacedConsumer : IConsumer<OrderPlacedEvent>
{
    private readonly PaymentService _paymentService;
    private readonly IPublishEndpoint _publish;

    public OrderPlacedConsumer(PaymentService paymentService,IPublishEndpoint publish)
    {
        _paymentService = paymentService;
        _publish = publish;
    }

    public async Task Consume(ConsumeContext<OrderPlacedEvent> context)
    {
        Console.WriteLine($"Processing payment for game {context.Message.GameId}");

        var approved =_paymentService.ProcessPayment(context.Message.Price);

        await _publish.Publish(
            new PaymentProcessedEvent(
                context.Message.UserId,
                context.Message.GameId,
                approved));
    }
}

