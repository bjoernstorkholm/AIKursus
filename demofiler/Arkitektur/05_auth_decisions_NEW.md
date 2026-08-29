# Authentication decision - NEW
Date: 2026-08-24
Owner: Security architecture

## Decision
New service-to-service integrations MUST use OAuth2 Client Credentials via the platform Identity Provider.

- No new API keys may be introduced.
- Existing API keys are legacy-only and should be removed when integrations are migrated.
- Customer Registry additionally requires mTLS at the ingress boundary.
- Azure Service Bus uses managed identity where supported.

## Status
APPROVED for Aurora implementation.

## Follow-up
Add the OAuth2 security scheme to the OpenAPI document. The current draft has not yet been updated.
