# Observability minimum for Aurora

Every incoming HTTP request has or receives a `correlationId`.
The same correlationId must survive:

HTTP -> Order Service -> outbox -> event -> consumer logs

Minimum structured log fields:
- timestamp
- service
- environment
- correlationId
- orderId when known
- eventName for async processing

IMPORTANT: the current OrderCreated JSON schema does not contain correlationId yet. Fix before consumers are frozen.
