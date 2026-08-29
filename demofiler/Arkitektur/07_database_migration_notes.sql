-- Aurora Order DB - migration sketch, NOT final
CREATE TABLE Orders (
    OrderId uniqueidentifier NOT NULL PRIMARY KEY,
    CustomerId nvarchar(80) NOT NULL,
    Status nvarchar(30) NOT NULL,
    Total decimal(18,2) NOT NULL,
    CreatedUtc datetime2 NOT NULL
);

-- TODO IDEMPOTENCY:
-- We require X-Client-Request-Id on POST /orders.
-- Need a table or unique constraint so retries do not create duplicate orders.
-- Questions: TTL 24h or 7 days? Store response body? What about concurrent identical requests?

-- TODO OUTBOX:
-- ADR says event after commit. Prefer transactional outbox, but no final schema yet.
