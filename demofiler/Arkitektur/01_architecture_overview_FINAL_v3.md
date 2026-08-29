# Aurora Platform - architecture overview FINAL v3

> Status: mostly final. Need to clean up old notes before handover.

## 1. Goal
Replace parts of the legacy order flow with a small set of services. First delivery focuses on Order Service and integrations to Customer Registry and Billing.

## 2. Core components
- Web/BFF
- Order Service (.NET)
- Customer Registry (external/internal masterdata API)
- Azure Service Bus
- Billing Adapter -> Legacy Billing SOAP
- Identity Provider

## 3. Order API
The Order Service owns order lifecycle.
Current draft base path: `/api/v1/orders`.
GET may be implemented first. POST needs idempotency protection.

## 4. Data ownership
Customer Registry owns customer masterdata.
Order Service stores only `customerId` plus order-specific snapshot fields where legally required.

## 5. Platform
Linux containers on the existing application platform.
Secrets MUST NOT be committed to configuration files.

## 6. Open cleanup
- Check whether API versioning stays `/v1` before pilot.
- Some old integration notes still mention API keys and Kafka. Those may be obsolete.
