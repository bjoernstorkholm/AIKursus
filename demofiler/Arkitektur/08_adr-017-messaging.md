# ADR-017: Messaging for Aurora
Status: Accepted
Date: 2026-08-20

## Context
Order Service must publish business events to multiple consumers. The platform already operates Azure Service Bus.

## Decision
Use Azure Service Bus topics for Aurora business events.

Initial topic: `aurora-orders`
Initial event: `OrderCreated`

Producer writes business data and an outbox record in the same database transaction. A background publisher sends the event.

## Consequences
- Consumers must tolerate at-least-once delivery.
- Event handlers must be idempotent.
- Schema versioning must be added before additional consumers onboard.

## Note
Older workshop notes mentioning Kafka are superseded by this ADR.
