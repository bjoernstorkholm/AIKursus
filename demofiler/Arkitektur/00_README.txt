ProjektRadar - Arkitekturoverblik demo
======================================

Disse filer forestiller en realistisk, rodet bunke arbejdsfiler fra en softwarearkitekt.
De er bevidst ikke helt konsistente.

Upload alle filerne i ProjektRadar og skift visning til "Arkitekturoverblik".

Bevidste uoverensstemmelser:
- Order API beskrives både som /api/v1/orders og /api/orders/v2.
- En gammel note foreskriver API key; en nyere beslutning siger OAuth2 client credentials.
- OrderCreated-eventet mangler correlationId, selv om observability-noten kræver det.
- Timeout/retry mod Customer Registry passer dårligt med upstream SLA.
- Idempotency for POST /orders er kun beskrevet som TODO.
- Messaging-platform er besluttet, men enkelte gamle noter nævner Kafka.
