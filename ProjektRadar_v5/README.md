# ProjektRadar

ProjektRadar.dk er en Blazor Interactive Server-demo på .NET 10 med to arbejdsformer:

1. **Projektkontrol** – samler projektdokumenter til et ledelsesoverblik over risici, konflikter, manglende beslutninger og prioriterede handlinger.
2. **Arkitekturoverblik** – samler rodede filer fra en softwarearkitekt til et udvikleroverblik over krav, interfaces, afhængigheder, modstridende specifikationer, beslutninger og åbne spørgsmål.

Tilstanden vælges i dropdown-menuen **Visning** til venstre for hovedmenuen.

## Kør på Windows

1. Installer .NET 10 SDK fra Microsoft, hvis det ikke allerede er installeret.
2. Udpak den leverede ZIP til eksempelvis `C:\ProjektRadar`.
3. Åbn PowerShell.
4. Kør:

```powershell
cd C:\ProjektRadar\ProjektRadar
dotnet restore
dotnet run
```

5. Åbn den lokale adresse, som `dotnet run` viser.

## Demoanalyse

Appen kører deterministisk i `Demoanalyse`. Ingen dokumentdata sendes til OpenAI eller andre eksterne AI-tjenester.

### Projektkontrol

Demofiler: `wwwroot/demo/Project-Aurora-Demofiler.zip`

### Arkitekturoverblik

Demofiler: `wwwroot/demo/Architecture-Messy-Demofiler.zip`

Arkitekturpakken indeholder 16 bevidst rodede tekstbaserede arbejdsfiler, herunder Markdown, YAML/OpenAPI, CSV, JSON Schema, SQL, PlantUML, HTTP, Proto og C# scratch-filer. Materialet indeholder realistiske konflikter om API-versionering, service-autentifikation, event payload, correlation ID, timeout/retry, idempotency og historiske arkitekturbeslutninger.

## Upload

Understøttede endelser:

- PDF, DOC/DOCX, XLS/XLSX, PPT/PPTX
- CSV, TXT, Markdown, JSON, XML, YAML, LOG og RTF
- SQL, HTTP, PlantUML (`.puml`), Proto (`.proto`), C# og `.csproj`

Drag'n'drop blokerer browserens standardhandling og videresender filerne til samme `<InputFile>`-changeflow som knappen `Vælg filer`.

## Arkitekturoverblik viser

- samlet specifikationsdækning
- teknisk systembillede
- dækning pr. område
- samlede krav med kilde og sikkerhedsstatus
- API'er og øvrige interfaces
- modstridende specifikationer med anbefalet arbejdshypotese
- komponentafhængigheder
- konkrete evidensspor til filerne
- udviklingsopgaver: hvad kan startes nu, og hvad er blokeret
- åbne spørgsmål til arkitekt/API-ejer/integrationsansvarlig
- beslutningsregister

## PDF-resultat

PDF-resultatet oprettes først, når brugeren klikker på `Download resultat som PDF`. JavaScript opretter en Blob og bruger browserens `download`-attribut. Der anvendes ikke `window.open()` eller `target="_blank"`.
