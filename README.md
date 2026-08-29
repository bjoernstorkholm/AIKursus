# ProjektRadar — komplet demonstrationspakke

ProjektRadar er en fiktiv, professionel Blazor-løsning, der krydslæser dokumenter fra et offentligt IT-projekt og omsætter dem til en visuel risikovurdering og handlingsplan. Pakken er lavet til en 15-minutters demonstration af, hvad man kan udvikle med ChatGPT.

## Pakken indeholder

- `ProjektRadar/` — den responsive Blazor-webapp med live OpenAI-integration og forberedt demoreserve.
- `demofiler/` — syv fiktive Aurora-dokumenter i PDF, Word, Excel, PowerPoint, CSV og tekst.
- `Drejebog_15_minutter.md` — ordret struktur, timing og demosikkerhed.
- `qa/Facitliste_ProjektRadar.json` — forventede fund til kontrol; denne fil må ikke uploades i demonstrationen.

## Den hurtige demonstration

1. Start appen efter vejledningen i `ProjektRadar/README.md`.
2. Åbn `http://localhost:5097` eller den webadresse, appen er udgivet på.
3. Pak demofilernes ZIP-fil ud, eller brug filerne direkte fra mappen `demofiler/`.
4. Vælg alle syv filer i uploadområdet og tryk **Start analyse**.
5. Resultatet vises direkte i browseren. Vis først ledelsesresuméet, derefter radargrafen, dokumentkonflikterne og Kanban-handlingsplanen.

PDF-filerne er kun kilder til analysen. Appen åbner ikke PDF'er automatisk. En PDF-version af det viste resultat kan downloades frivilligt fra resultatsiden.

## Hvad analysen bør opdage

- Budgetramme på 12,0 mio. kr. mod forecast på 12,65 mio. kr.
- Godkendt go-live 30. november 2026 mod leverandørens prognose 14. december 2026.
- Obligatorisk penetrationstest før go-live, booket 1.–3. december.
- Foreslået dataejer uden formaliseret acceptmandat og 1,6 % afviste poster.
- Gul status med styringsdokumenter, der endnu ikke er fuldt synkroniseret.
- Integrationstest cirka ét sprint efter planen.

Alle personer, beløb, projekter og hændelser er opdigtede. Materialet indeholder ingen rigtige personoplysninger eller fortrolige data.
