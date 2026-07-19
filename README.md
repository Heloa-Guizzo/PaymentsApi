# PaymentsAPI

## Overview

The PaymentsAPI is responsible for payment processing within the Gaming Platform.

The service receives purchase requests, validates payment information, and publishes the payment outcome.

This implementation simulates payment processing for educational purposes.

---

## Responsibilities

- Payment validation
- Payment approval simulation
- Payment rejection simulation
- Publishing payment status events

---

## Technologies

- .NET 8
- ASP.NET Core Web API
- RabbitMQ
- MassTransit

---

## Architecture Role

The PaymentsAPI operates as an event consumer and producer.

It receives purchase requests from the CatalogAPI and returns payment results to the platform using asynchronous messaging.

---

## Consumed Events

### OrderPlacedEvent

Example:

```json
{
  "userId": "guid",
  "gameId": "guid",
  "price": 99.90
}
```

---

## Published Events

### PaymentProcessedEvent

Example:

```json
{
  "userId": "guid",
  "gameId": "guid",
  "approved": true
}
```

---

## Payment Workflow

```text
CatalogAPI
    │
    ▼
OrderPlacedEvent
    │
    ▼
PaymentsAPI
    │
    ▼
PaymentProcessedEvent
```

---

## Validation Rule

Current payment approval rule:

```text
Price <= 100 → Approved
Price > 100 → Declined
```

This rule exists only to simulate a payment gateway.

---

## Environment Configuration

```text
RabbitMQ__Host
```

---

## Running the Service

### Using Visual Studio

Run the service normally.

### Using CLI

```bash
dotnet restore
dotnet build
dotnet run
```

---

## Swagger

```text
http://localhost:5003/swagger
```

---

## Dependencies

- RabbitMQ

---
