using ProjektRadar.Models;

namespace ProjektRadar.Services;

public sealed class ArchitectureAnalysisService
{
    public Task<ArchitectureAnalysis> AnalyzeAsync(IReadOnlyList<UploadedDocument> documents)
    {
        var sourceNames = documents.Count == 0
            ? "Arkitekturoverblik-demofiler"
            : string.Join(", ", documents.Select(d => d.Name).Take(5)) + (documents.Count > 5 ? " m.fl." : string.Empty);

        var analysis = new ArchitectureAnalysis
        {
            SpecificationCoverage = 68,
            CoverageLevel = "Delvist afklaret",
            ExecutiveSummary = $"Materialet beskriver en brugbar retning for Aurora Platform, men flere centrale specifikationer modsiger hinanden. En udvikler kan begynde på domænemodellen og read-only API'er, mens autentifikation, event-kontrakt og retry/timeout-politik bør afklares før integrationsarbejdet låses. Analysen er deterministisk demoanalyse baseret på {sourceNames}.",
            Areas =
            [
                new("Domæne og data", 86, "God", "Ordre, kunde og leverance er beskrevet konsistent nok til første implementering."),
                new("REST API", 74, "Delvis", "Ressourcerne er kendte, men versionering og enkelte routes er i konflikt."),
                new("Autentifikation", 42, "Uklar", "Ældre noter siger API key, nyere ADR siger OAuth2 client credentials."),
                new("Events", 55, "Uklar", "Broker er besluttet, men eventnavn og payload er ikke entydige."),
                new("Fejlhåndtering", 61, "Delvis", "Retry er nævnt, men timeout og idempotency er ikke færdigdefineret."),
                new("Observability", 48, "Mangelfuld", "Correlation ID er nævnt i noter, men mangler i eventudkastet."),
                new("Deployment", 78, "God", "Containerisering og miljøer er rimeligt beskrevet; secrets-strategi mangler."),
            ],
            Requirements =
            [
                new("REQ-001", "Ordre", "Systemet skal kunne oprette og hente ordrer via HTTP API.", "Klar", "01_architecture_overview_FINAL_v3.md – afsnit 2"),
                new("REQ-002", "Ordre", "POST af samme klient-request-id må ikke oprette dubletter.", "Kræver afklaring", "07_database_migration_notes.sql – TODO + 03_api_contract_draft.yaml"),
                new("REQ-003", "Integration", "Ordreoprettelse skal publicere en asynkron hændelse til integrationslaget.", "Klar", "08_adr-017-messaging.md"),
                new("REQ-004", "Sikkerhed", "Service-til-service kald skal autentificeres uden brugerlogin.", "Klar", "05_auth_decisions_NEW.md"),
                new("REQ-005", "Sikkerhed", "Den konkrete autentifikationsmekanisme skal være OAuth2 client credentials.", "I konflikt", "05_auth_decisions_NEW.md / 04_old_integration_notes.txt"),
                new("REQ-006", "Observability", "Alle synkrone og asynkrone kald skal kunne spores på tværs af services.", "Delvis", "10_observability_notes.md / 06_order-created.schema.json"),
                new("REQ-007", "Integration", "Eksterne registerkald skal have timeout og kontrolleret retry.", "Kræver afklaring", "04_integration_matrix.csv / 11_vendor_mail_export.txt"),
                new("REQ-008", "Data", "Kundedata gemmes som reference-id; masterdata ejes af Customer Registry.", "Klar", "01_architecture_overview_FINAL_v3.md – afsnit 4"),
            ],
            Interfaces =
            [
                new("Order HTTP API", "Web/BFF", "Order Service", "HTTPS/REST", "OpenAPI draft", "OAuth2?", "Route i konflikt", "03_api_contract_draft.yaml / 02_random_whiteboard_notes.txt"),
                new("Customer Registry", "Order Service", "Customer Registry", "HTTPS/REST", "GET /customers/{id}", "mTLS + token", "Næsten klar", "04_integration_matrix.csv"),
                new("OrderCreated event", "Order Service", "Integration workers", "Azure Service Bus", "JSON event schema", "Managed identity", "Payload i konflikt", "06_order-created.schema.json / 08_adr-017-messaging.md"),
                new("Legacy Billing", "Billing Adapter", "Legacy Billing", "SOAP/XML", "WSDL 2019", "Service account", "Teknisk gæld", "04_old_integration_notes.txt"),
            ],
            Conflicts =
            [
                new(
                    "API-versionering",
                    "03_api_contract_draft.yaml – base path: /api/v1/orders",
                    "02_random_whiteboard_notes.txt – 'drop v1, use /api/orders/v2 before pilot'",
                    "Klienter og tests kan blive bygget mod forskellige routes.",
                    "Behold /api/v1/orders som implementeringsbaseline, indtil API-ejer har godkendt en ny kontrakt."),
                new(
                    "Service-autentifikation",
                    "04_old_integration_notes.txt – X-API-Key bruges mellem interne services",
                    "05_auth_decisions_NEW.md – OAuth2 client credentials; API keys må ikke bruges i ny kode",
                    "Udvikleren kan vælge en mekanisme, som senere skal fjernes af sikkerhedsårsager.",
                    "Brug OAuth2 client credentials som nyeste beslutning; markér API-key-noten som historisk."),
                new(
                    "OrderCreated payload",
                    "06_order-created.schema.json – customerId + orderId; correlationId mangler",
                    "10_observability_notes.md – correlationId er obligatorisk på alle events",
                    "Tracing og downstream-fejlsøgning bliver inkonsistent.",
                    "Tilføj correlationId til event-kontrakten før producer og consumers implementeres."),
                new(
                    "Timeout mod Customer Registry",
                    "04_integration_matrix.csv – timeout 15 sekunder, retry 3 gange",
                    "11_vendor_mail_export.txt – upstream SLA antager maks. 5 sekunder pr. kald",
                    "Worst case kan ét ordre-kald blokere langt over den forventede svartid.",
                    "Afklar samlet time budget; brug ikke 15s x 3 som produktionsstandard."),
            ],
            Decisions =
            [
                new("Messaging platform", "Azure Service Bus topics", "Besluttet", "08_adr-017-messaging.md"),
                new("Container runtime", "Linux containers i eksisterende platform", "Besluttet", "01_architecture_overview_FINAL_v3.md"),
                new("Service auth", "OAuth2 client credentials", "Ny beslutning – gammel note findes stadig", "05_auth_decisions_NEW.md"),
                new("API versioning", "Ikke endeligt besluttet", "Åben", "03_api_contract_draft.yaml / 02_random_whiteboard_notes.txt"),
            ],
            Dependencies =
            [
                new("Order Service", "Customer Registry", "Validering af kunde og opslag af masterdata", "Medium", "04_integration_matrix.csv"),
                new("Order Service", "Azure Service Bus", "Publicering af OrderCreated", "Høj", "08_adr-017-messaging.md"),
                new("Billing Adapter", "Legacy Billing SOAP", "Efterfølgende fakturering", "Høj", "04_old_integration_notes.txt"),
                new("Alle services", "Identity Provider", "Client credentials tokens", "Høj", "05_auth_decisions_NEW.md"),
            ],
            OpenQuestions =
            [
                new("Hvad er den autoritative base route og versionsstrategi for Order API?", "Controller, OpenAPI og integrationstests afhænger af svaret.", "API-ejer / arkitekt", "Kritisk", "03_api_contract_draft.yaml / 02_random_whiteboard_notes.txt"),
                new("Skal OrderCreated indeholde correlationId og schemaVersion?", "Consumers bør ikke implementeres mod en ustabil event-kontrakt.", "Arkitekt + integrationsansvarlig", "Kritisk", "06_order-created.schema.json / 10_observability_notes.md"),
                new("Hvad er det samlede timeout-budget mod Customer Registry?", "Retry-politikken kan ellers overskride API'ets SLA.", "Arkitekt + leverandør", "Høj", "04_integration_matrix.csv / 11_vendor_mail_export.txt"),
                new("Hvor lagres idempotency keys, og hvor længe?", "Dubletbeskyttelse ved POST er kun omtalt som TODO.", "Order team", "Høj", "07_database_migration_notes.sql"),
            ],
            Tasks =
            [
                new() { Id = 1, Title = "Implementér domænemodel og read-only Order API", Detail = "Kan startes uden de åbne integrationsbeslutninger.", Area = "Backend", Priority = "Høj", Status = "Klar", Evidence = "REQ-001 + arkitekturoverblik" },
                new() { Id = 2, Title = "Frys OpenAPI base path", Detail = "Afklar v1 kontra v2 før write endpoints og klient-SDK bygges.", Area = "API", Priority = "Kritisk", Status = "Blokeret", Evidence = "API-versioneringskonflikt" },
                new() { Id = 3, Title = "Opdatér OrderCreated schema", Detail = "Tilføj correlationId og schemaVersion, og få consumer-ejere til at godkende.", Area = "Events", Priority = "Kritisk", Status = "Blokeret", Evidence = "Event payload-konflikt" },
                new() { Id = 4, Title = "Implementér OAuth2 client credentials", Detail = "Brug den nye ADR-lignende beslutning og ignorer historisk API-key-note.", Area = "Security", Priority = "Høj", Status = "Klar", Evidence = "05_auth_decisions_NEW.md" },
                new() { Id = 5, Title = "Design idempotency storage", Detail = "Dokumentér key, TTL og concurrency-adfærd før POST /orders færdiggøres.", Area = "Data", Priority = "Høj", Status = "Afventer", Evidence = "07_database_migration_notes.sql" },
            ],
            Evidence =
            [
                new("03_api_contract_draft.yaml – paths", "/api/v1/orders", "Nuværende maskinlæsbare API-udkast"),
                new("05_auth_decisions_NEW.md – beslutning", "New services use OAuth2 client credentials. Do not add new API keys.", "Nyeste sikkerhedsretning"),
                new("06_order-created.schema.json – properties", "orderId, customerId, total, occurredAt", "Event-kontrakten mangler correlationId"),
                new("08_adr-017-messaging.md", "Decision: Azure Service Bus topics", "Valgt messaging-platform"),
                new("10_observability_notes.md", "correlationId must survive HTTP -> event -> consumer", "Tværgående tracingkrav"),
            ]
        };

        return Task.FromResult(analysis);
    }
}
