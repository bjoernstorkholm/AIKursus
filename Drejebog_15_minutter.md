# Drejebog: 15 minutter med ProjektRadar

## 0:00–1:00 — Åbning

Sig:

> “Forestil jer et offentligt IT-projekt med syv dokumenter, forskellige versioner og en styregruppe, der kun har få minutter. Kan AI finde det, som er svært at se på tværs?”

Vis forsiden. Fortæl, at målet ikke er en chatbot, men et konkret arbejdsredskab, der går fra dokumenter til beslutninger.

## 1:00–3:00 — Problemet

Forklar kort:

- Projektinformation ligger spredt i planer, budgetter, referater, mails og leverandørslides.
- Den største risiko ligger ofte mellem dokumenterne: forskellige datoer, tal og statusvurderinger.
- En leder har brug for sporbarhed og næste handling — ikke en lang AI-tekst.

## 3:00–4:00 — Løsningen

Scroll gennem de fire trin: **Upload → Scan → Forstå → Handl**.

Sig:

> “Jeg bad ChatGPT hjælpe mig fra idé og produktspørgsmål til fiktive data, tilgængeligt design, kode og en rigtig AI-integration.”

Peg på det lyse, let grå design, kompasset og den tydelige navigation. Nævn, at farver aldrig står alene; hvert signal har også tekst og score.

## 4:00–8:30 — Demonstrationen

1. Tryk **Hent Aurora-demofiler**, og pak ZIP-filen ud på forhånd.
2. Vælg alle syv filer på én gang.
3. Vis filoversigten og de forskellige formater. Analysen starter automatisk efter upload.
4. Mens scanningen kører, forklar at AI’en læser filerne samlet og får et fast JSON-skema, så resultatet kan visualiseres konsekvent.

Resultatet vises direkte i browseren. Åbn ikke kildedokumenterne under demonstrationen, og brug ikke en PDF-rapport som mellemtrin. Knappen **Download resultat som PDF** er en valgfri eksport, som du kan nævne til sidst uden at forlade resultatsiden.

Undgå at vise kode eller API-indstillinger. Hvis appen viser **Forberedt demoreserve**, sig:

> “Live-forbindelsen er ikke aktiv i dette miljø, så løsningen bruger det kontrollerede Aurora-facit. Hele brugerrejsen og resultatvisningen er den samme; mærkningen gør det transparent.”

## 8:30–11:30 — De tre stærkeste fund

Start med risikoscoren og radargrafen. Vis derefter disse konflikter:

1. **Dato:** Projektplanen siger 30. november; leverandøren siger 14. december.
2. **Sikkerhed:** Penetrationstest er obligatorisk før lancering og er booket 1.–3. december — efter baseline, men før den foreslåede december-release.
3. **Økonomi:** 12,0 mio. kr. er godkendt; forecast er 12,65 mio. kr., og håndteringen mangler styregruppegodkendelse.

Peg på kildeetiketterne. Sig:

> “Det interessante er ikke, at AI kan opsummere én fil. Det interessante er, at den kan opdage en styringskonflikt på tværs og vise præcis, hvor oplysningerne kommer fra.”

## 11:30–13:30 — Fra risiko til handling

Vis Kanban-tavlen og skift derefter til tidslinjen.

Fremhæv:

- bekræft dataejerens acceptmandat;
- beslut én go-live-dato;
- bekræft test- og retestplanen;
- godkend håndteringen af budgetafvigelsen;
- synkronisér styringsdokumenterne.

Forklar, at hver handling har ejer, frist, prioritet og begrundelse. Dermed bliver resultatet anvendeligt på næste styregruppemøde.

## 13:30–14:30 — Hvad der er lavet med ChatGPT

Opsummér processen:

- ChatGPT stillede afklarende hv-spørgsmål om målgruppe, datatyper, funktioner og design.
- Det skabte et sammenhængende, fiktivt dokumentunivers med kontrollerede konflikter.
- Det byggede Blazor-koden, den responsive brugerflade, AI-prompten og det stramme resultatskema.
- Det lavede også demoens drejebog og facitliste.

## 14:30–15:00 — Afslutning

Sig:

> “Min vigtigste pointe er, at god brug af ChatGPT ikke er ét smart spørgsmål. Det er en styret proces: afklar behovet, giv realistisk kontekst, byg noget konkret, og gør resultatet efterprøvbart.”

Slut på handlingsplanen — ikke på uploadskærmen.

## Før du går på

- Pak demofilerne ud og hav dem åbne i en mappe.
- Start appen mindst fem minutter før.
- Kontrollér, at browserzoom er 100 %, og luk personlige faner/notifikationer.
- Test både live AI og demoreserven.
- Upload aldrig `qa/Facitliste_ProjektRadar.json` som input.
- Hav appen åben i to faner: én ren startside og én med færdigt resultat.
