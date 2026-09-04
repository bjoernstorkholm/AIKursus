# Validering af ProjektRadar-pakken

## Kontrolleret i leveringsmiljøet

- Projektet targeter `net10.0`.
- `Program.cs` indeholder `AddInteractiveServerComponents()` og `AddInteractiveServerRenderMode()`.
- `ArchitectureAnalysisService` er registreret i DI-containeren.
- Komponenten bruger `@rendermode InteractiveServer`, og `Microsoft.JSInterop` er importeret.
- JavaScript-kilden består `node --check`.
- Kildekoden til runtime-flowet indeholder ikke `window.open()` eller `target="_blank"`.
- Drag'n'drop-koden kalder `preventDefault()`, overfører `DataTransfer.files` til det samme filinput og udsender samme `change`-event som filvælgeren.
- Begge analyseformer bruger det samme uploadflow.
- PDF-service kaldes kun fra brugerens klik på `Download resultat som PDF`.
- Browserdownload sker via Blob + `download`-attribut, ikke via en ny fane.
- Projektkontrol-demofilen findes fortsat som `Project-Aurora-Demofiler.zip`.
- Den nye arkitektur-demo består `zip -T` og indeholder 16 filer.
- Arkitektur-demoen indeholder bevidste konflikter om API-versionering, auth, event schema, correlation ID, timeout/retry og idempotency.
- `Home.razor` indeholder ikke længere SVG `<text>`-tags; radarlabels bruger `foreignObject`, så den tidligere RZ1023-fejl ikke genintroduceres.
- Nye arkitekturtekstformater er tilføjet både til HTML-filvælgerens `accept` og serverens `AllowedExtensions`/`TextExtensions`.

## Build-verifikation

`.NET SDK` er ikke installeret i leveringsmiljøet, så buildet kunne ikke køres her. Den 4. september 2026 bekræftede brugeren, at `dotnet build` er kørt manuelt og består med hjælpefunktionen implementeret.

## Hjælp i topmenuen

- Hjælpeknappen åbner og lukker et overflow-panel i topmenuen.
- Hjælpeteksten tilpasses den valgte visning.
- Trigger og panel er forbundet med `aria-expanded`, `aria-controls` og `aria-labelledby`.
- Panelet har en navngivet luk-knap og er begrænset til viewportens bredde og højde.
- På mobil reduceres triggeren til et kompakt spørgsmålstegnsikon.

## Layout refinement

Layoutet er gennemgået og gjort mere kompakt og ensartet i begge visninger.

- Hero-overskrift reduceret fra op til 68 px til op til 52 px.
- Sektionsoverskrifter reduceret fra op til 43 px til op til 34 px.
- Underoverskrifter og paneloverskrifter reduceret tilsvarende.
- Ensartet sektionsafstand via fælles spacing-variabler.
- Mindre og mere konsistent padding i uploadområde, demoguide, KPI-kort, risikokort, konfliktkort, arkitekturpaneler, tabeller og handlingskort.
- Desktop side-margin normaliseret til 24 px før max-bredde; tablet 16 px; mobil 12 px.
- Hero og visualiseringer gjort lavere for at undgå unødvendigt tomrum.
- Mobiltypografi og mobilafstande er reduceret særskilt.

Statisk kontrol: CSS-klammer balancerer, JavaScript består `node --check`, ingen SVG `<text>` i Razor, ingen `window.open()` og ingen `target="_blank"`.

2026-08-27 layout fix:
- Removed any border/outline/shadow/background frame from the hero heading in both modes.

## Layoutrettelse – Kontrakter og integrationspunkter
- Sektionen er ændret fra to kompakte kortkolonner til én bred, skannbar integrationsliste.
- Fra/Til vises som tydelige endpoints med en separat retningspil.
- Kontrakt, autentifikation og evidens er opdelt i egne felter med kontrolleret tekstombrydning.
- Mobil-layoutet stabler endpoints og metadata lodret.
- Ældre `.interface-route strong`-styling er eksplicit neutraliseret for de nye endpointfelter.
