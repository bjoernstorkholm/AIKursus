# Drejebog: 15 minutter med ProjektRadar

## Formål

Demonstrér ProjektRadar som et konkret eksempel på, hvordan ChatGPT kan bruges til at udvikle et arbejdsredskab, der gør komplekst dokumentmateriale overskueligt.

Demoen viser to arbejdsformer i samme webapp:

1. **Projektkontrol** – målrettet projektledere, styregruppe, programledelse, IT-ledelse og Product Owners.
2. **Arkitekturoverblik** – målrettet softwareudviklere, der skal skabe overblik i rodede og modstridende arkitektfiler.

Appen kører i **Demoanalyse**. Resultatet er deterministisk, så demonstrationen bliver ens hver gang, og ingen dokumentdata sendes eksternt.

---

## 0:00–1:00 — Åbning

Vis forsiden i **Projektkontrol**.

Sig:

> “Forestil jer et offentligt IT-projekt, hvor sandheden er fordelt mellem projektplan, budget, sikkerhedsplan, leverandørstatus, risikolog og styregruppereferat. Det svære er ikke nødvendigvis at læse én fil — det svære er at opdage, når filerne siger forskellige ting.”

Peg kort på:

- ProjektRadar-logoet med radar-symbolik;
- dropdownen **Visning** til venstre for menuen;
- **Start analyse**;
- **Vis eksempelresultat**;
- **Download demofiler**.

Fremhæv:

> “Det her er ikke en chatbot ved siden af arbejdet. Det er et konkret workflow, hvor dokumenter bliver omsat til et visuelt og handlingsklart overblik.”

---

## 1:00–2:00 — To målgrupper i samme løsning

Peg på dropdownen **Visning**, men bliv foreløbig i **Projektkontrol**.

Forklar:

- **Projektkontrol** svarer på: *Hvad skal ledelsen være bekymret for, beslutte og følge op på?*
- **Arkitekturoverblik** svarer på: *Hvad kan udvikleren faktisk implementere, og hvilke specifikationer er stadig uklare eller modstridende?*

Sig:

> “Det interessante er, at grundflowet er det samme: filer ind, struktur og konflikter ud. Men resultatet tilpasses den person, der skal bruge det.”

---

## 2:00–3:30 — Uploadflowet

Scroll til **Dokumenter**.

Vis uploadområdet og forklar:

- filer kan vælges med **Vælg filer**;
- de kan også trækkes direkte ind med drag’n’drop;
- begge metoder bruger det samme Blazor-uploadflow;
- drag’n’drop åbner ikke PDF- eller dokumentfiler i nye faner;
- analysen starter automatisk efter upload.

Brug Projekt Aurora-demofilerne.

Demopakken indeholder 8 dokumenter i forskellige formater, fx:

- Word;
- Excel;
- PowerPoint;
- PDF;
- CSV;
- TXT.

Sig:

> “Formatet er ikke pointen. Pointen er, at informationen ligger spredt, og at brugeren normalt selv skal sammenholde den.”

Hvis tiden er knap, brug **Vis eksempelresultat** i stedet for at uploade filerne live.

---

## 3:30–6:00 — Projektkontrol: ledelsesoverblik

Gå til **Analyse**.

Fremhæv de fire nøgletal:

- **Samlet risikoniveau: 78 / 100 – Høj**
- **Dokumentkonflikter: 4**
- **Manglende beslutninger: 4**
- **Kritiske handlinger: 2**

Vis radarvisualiseringen.

Forklar, at den samler projektets udsathed på tværs af:

- tidsplan;
- økonomi;
- sikkerhed;
- governance;
- leverandør;
- data;
- beslutninger.

Sig:

> “En leder behøver ikke først at forstå alle dokumenterne. ProjektRadar starter med det samlede signal og viser derefter, hvorfor signalet ser sådan ud.”

Peg derefter på **Ledelsespunkter først**:

- fastlæg én bindende go-live-dato;
- godkend finansiering af forecast;
- udpeg endelig dataejer.

---

## 6:00–8:00 — Risici, konflikter og evidens

Gå til **Risikovurdering**.

Start med de to mest tydelige risici:

1. **Go-live uden afsluttet sikkerhedstest** – score 92, Kritisk.
2. **Budgetoverskridelse uden godkendt finansiering** – score 81, Høj.

Vis derefter dokumentkonflikterne.

Brug især:

### Go-live

Projektplanen og styringsmaterialet arbejder ikke med samme realistiske dato.

Sig:

> “Det vigtige er ikke bare, at systemet siger ‘tidsplanen er risikabel’. Det viser også hvilke dokumenter og formuleringer konklusionen bygger på.”

### Sikkerhedstest

Testplanen kræver afsluttet penetrationstest før go-live, mens leverandørens testslot ligger efter den gældende baseline.

### Økonomi

Den godkendte ramme er **12,0 mio. kr.**, mens seneste forecast er **12,65 mio. kr.** — altså **0,65 mio. kr. over rammen**.

Fremhæv evidensprincippet:

> “En konklusion uden kilde er bare endnu en påstand. Derfor er evidens en del af selve brugerfladen.”

---

## 8:00–9:30 — Fra risiko til handling

Gå til **Handlingsplan**.

Vis, at brugeren kan redigere:

- ansvarlig rolle;
- deadline;
- prioritet;
- status.

Vis derefter Kanban-tavlen.

Fremhæv fx:

- **Beslut revideret go-live**
- **Lås sikkerhedstestplan**
- **Udpeg dataejer**

Skift kort til tidslinjen.

Sig:

> “Analysen stopper ikke ved ‘her er problemerne’. Den omsætter fundene til en arbejdsplan med ejer, frist, prioritet og status.”

Nævn til sidst:

- **Download resultat som PDF** er en valgfri eksport;
- PDF’en genereres først, når brugeren klikker;
- resultatet åbnes ikke automatisk i en ny browserfane.

---

## 9:30–10:00 — Skift perspektiv

Scroll til toppen.

Åbn dropdownen **Visning** og vælg:

**Arkitekturoverblik**

Peg på, at navigationen nu ændrer sig til:

- **Filer**
- **Specifikationer**
- **Konflikter**
- **Udviklingsplan**

Sig:

> “Nu er brugeren ikke længere styregruppen. Nu er brugeren en softwareudvikler, som har fået en bunke halvfærdige arkitektfiler.”

---

## 10:00–11:00 — Arkitektens filkaos

Vis forsiden i **Arkitekturoverblik**.

Peg på eksemplerne i hero-området:

- `/api/v1/orders`
- en anden note, der foreslår `/api/orders/v2`
- OAuth2 client credentials
- manglende `correlationId`

Sig:

> “Det her er meget tættere på den virkelighed, en udvikler ofte møder: FINAL_v3, gamle noter, et OpenAPI-udkast, en ADR, SQL-TODO’er og en mail fra en leverandør.”

Gå til **Filer**.

Arkitektur-demopakken indeholder 16 bevidst rodede arbejdsfiler, blandt andet:

- Markdown;
- YAML/OpenAPI;
- CSV;
- JSON Schema;
- SQL;
- PlantUML;
- HTTP;
- Proto;
- C#.

Hvis du vil holde demoen hurtig, kan du nøjes med et repræsentativt udvalg af filerne.

---

## 11:00–12:30 — Arkitekturoverblik: hvad ved vi egentlig?

Gå til **Specifikationer**.

Fremhæv:

- **Specifikationsdækning: 68 %**
- **Konflikter: 4**
- **Interfaces: 4**
- **Åbne spørgsmål: 4**

Forklar:

> “Her er målet ikke en risikoscore til ledelsen. Målet er at afgøre, hvor meget af materialet der er entydigt nok til at kode efter.”

Vis kravlisten og statusmarkeringerne:

- **Klar**
- **Kræver afklaring**
- **I konflikt**

Brug fx:

- systemet skal kunne oprette og hente ordrer via HTTP API;
- POST med samme client-request-id må ikke skabe dubletter;
- autentifikation skal bruge OAuth2 client credentials.

Peg igen på kildefilerne.

---

## 12:30–13:30 — Kontrakter og integrationspunkter

Scroll til **Kontrakter og integrationspunkter**.

Fremhæv det visuelle flow:

**Fra → Til**

Vis, at hvert integrationspunkt samler:

- protokol;
- kildekomponent;
- målkomponent;
- kontrakt;
- autentifikation;
- evidens.

Brug fx:

- Order Service → Customer Registry;
- OrderCreated event → Integration workers;
- Legacy Billing.

Sig:

> “Udvikleren behøver ikke gætte sig frem gennem fem filer. De relevante oplysninger samles i ét integrationskort, men stadig med sporbarhed tilbage til originalmaterialet.”

---

## 13:30–14:30 — Hvad kan jeg kode nu?

Gå til **Udviklingsplan**.

Vis forskellen mellem **Klar** og **Blokeret**.

Fremhæv fx:

### Klar

**Implementér domænemodel og read-only Order API**

Det kan påbegyndes uden de åbne integrationsbeslutninger.

### Blokeret

**Frys OpenAPI base path**

Der skal vælges mellem modstridende versioneringsstrategier, før write-endpoints og klient-SDK bygges.

### Blokeret

**Opdatér OrderCreated schema**

`correlationId` og `schemaVersion` skal afklares.

Vis derefter:

- åbne spørgsmål til arkitekt/API-ejer;
- beslutningsregisteret.

Sig:

> “Det afgørende output for udvikleren er ikke ‘her er et resume’. Det er: dette kan du bygge nu, dette er blokeret, og her er præcis det spørgsmål, der skal besvares.”

---

## 14:30–15:00 — Afslutning

Gå evt. tilbage til toppen, så dropdownen **Visning** er synlig.

Sig:

> “ProjektRadar demonstrerer et vigtigt princip: god brug af ChatGPT handler ikke kun om at generere tekst. Det handler om at skabe et kontrolleret workflow, hvor ustruktureret information bliver til overblik, evidens og handling — tilpasset den person, der skal bruge resultatet.”

Afslut med de to perspektiver:

- **Ledelsen får beslutningsklarhed.**
- **Udvikleren får implementeringsklarhed.**

Og:

> “Samme filkaos. Forskelligt behov. Samme grundidé: gør det komplekse handlingsbart.”

---

# Før du går på

- Start ProjektRadar mindst fem minutter før demonstrationen.
- Hav **Projektkontrol** åben på forsiden.
- Hav Projekt Aurora-demofilerne udpakket i en mappe.
- Hav arkitektur-demofilerne udpakket i en separat mappe.
- Kontrollér browserzoom på 100 %.
- Luk personlige faner og notifikationer.
- Test **Vælg filer**.
- Test drag’n’drop.
- Kontrollér at drag’n’drop ikke åbner PDF’er i nye faner.
- Test **Vis eksempelresultat**.
- Test dropdownen **Visning → Arkitekturoverblik**.
- Test **Vis udviklereksempel**.
- Kontrollér **Kontrakter og integrationspunkter** visuelt.
- Test at statusfelter i handlings-/udviklingsplanen kan ændres.
- Test **Download resultat som PDF** i begge modes.
- Husk: appen kører som **Demoanalyse**; ingen dokumentdata sendes eksternt.
- Hav gerne to browserfaner klar som backup:
  - én med Projektkontrol-resultatet;
  - én med Arkitekturoverblik-resultatet.

---

# Hvis tiden skrider

Prioritér i denne rækkefølge:

1. Forside + forklaring af de to modes.
2. Projektkontrol: 78/100 + én dokumentkonflikt + handlingsplan.
3. Skift til Arkitekturoverblik.
4. 68 % specifikationsdækning + én konflikt.
5. **Kontrakter og integrationspunkter**.
6. **Hvad kan jeg kode nu?**
7. Afslutningsbudskabet.

Spring live-upload over og brug **Vis eksempelresultat** / **Vis udviklereksempel**, hvis tiden er presset.
