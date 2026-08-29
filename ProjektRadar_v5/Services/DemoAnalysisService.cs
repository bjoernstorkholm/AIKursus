using ProjektRadar.Models;

namespace ProjektRadar.Services;

public sealed class DemoAnalysisService
{
    public Task<ProjectAnalysis> AnalyzeAsync(IReadOnlyList<UploadedDocument> documents)
    {
        var sourceNames = documents.Count == 0
            ? "Projekt Aurora-demofiler"
            : string.Join(", ", documents.Select(d => d.Name).Take(4)) + (documents.Count > 4 ? " m.fl." : string.Empty);

        var analysis = new ProjectAnalysis
        {
            RiskScore = 78,
            RiskLevel = "Høj",
            ExecutiveSummary = $"Projekt Aurora har et højt samlet risikoniveau. De vigtigste ledelsespunkter er en uafklaret go-live-dato, budgetoverskridelse, forsinket sikkerhedstest og uklart dataejerskab. Analysen er deterministisk demoanalyse baseret på {sourceNames}.",
            RadarMetrics =
            [
                new("Tidsplan", 84),
                new("Økonomi", 76),
                new("Sikkerhed", 91),
                new("Governance", 71),
                new("Leverandør", 64),
                new("Data", 79),
                new("Beslutninger", 86)
            ],
            Risks =
            [
                new()
                {
                    Title = "Go-live uden afsluttet sikkerhedstest",
                    Description = "Sikkerhedstesten kan først afsluttes efter den dato, som projektplanen fortsat angiver som go-live.",
                    Probability = "Høj",
                    Consequence = "Kritisk",
                    Score = 92,
                    Level = "Kritisk",
                    Evidence = "04_Sikkerhed_og_testplan_Aurora.docx – side 3; 02_Projektplan_Aurora.docx – side 4"
                },
                new()
                {
                    Title = "Budgetoverskridelse uden godkendt finansiering",
                    Description = "Seneste forecast er højere end den godkendte ramme, mens finansiering af merforbruget ikke fremgår som besluttet.",
                    Probability = "Høj",
                    Consequence = "Høj",
                    Score = 81,
                    Level = "Høj",
                    Evidence = "03_Budget_Aurora.xlsx – Forecast; 01_Projektcharter_Aurora.docx – side 2"
                },
                new()
                {
                    Title = "Uklart dataejerskab",
                    Description = "Projektcharter og dataejerskabsnotat peger på forskellige ejere af de centrale dataobjekter.",
                    Probability = "Mellem",
                    Consequence = "Høj",
                    Score = 72,
                    Level = "Høj",
                    Evidence = "05_Dataejerskab_Aurora.pdf – side 2; 01_Projektcharter_Aurora.docx – side 3"
                },
                new()
                {
                    Title = "Leverandørkapacitet er overvurderet",
                    Description = "Statusmaterialet viser grøn leverandørstatus, men leverandørens egen plan mangler navngivne testressourcer i kritiske uger.",
                    Probability = "Mellem",
                    Consequence = "Høj",
                    Score = 68,
                    Level = "Høj",
                    Evidence = "06_Leverandorstatus_Aurora.pptx – slide 4; 07_Risikolog_Aurora.csv – række 5"
                }
            ],
            Conflicts =
            [
                new(
                    "Go-live-dato",
                    "Projektplanen fastholder 15. oktober 2026, mens styregruppereferatet beskriver 1. november som den realistiske dato.",
                    "02_Projektplan_Aurora.docx – side 4 – \"Go-live 15. oktober 2026\"",
                    "08_Styregruppereferat_Aurora.txt – afsnit 3 – \"Realistisk go-live er 1. november\"",
                    "Plan, kommunikation og bemanding styres efter forskellige datoer."),
                new(
                    "Budgetramme",
                    "Projektcharteret angiver 11,2 mio. kr., mens forecast viser 13,1 mio. kr.",
                    "01_Projektcharter_Aurora.docx – side 2 – \"Godkendt ramme: 11,2 mio. kr.\"",
                    "03_Budget_Aurora.xlsx – Forecast – \"Forventet slutforbrug: 13,1 mio. kr.\"",
                    "Der mangler en finansieret beslutning om 1,9 mio. kr."),
                new(
                    "Sikkerhedstest",
                    "Testplanen kræver afsluttet penetrationstest før go-live, men leverandørstatus placerer testen efter den planlagte go-live.",
                    "04_Sikkerhed_og_testplan_Aurora.docx – side 3 – \"Penetrationstest skal være lukket før produktionssætning\"",
                    "06_Leverandorstatus_Aurora.pptx – slide 5 – \"Første ledige testslot: 23. oktober\"",
                    "Projektet kan ikke følge både sikkerhedskrav og gældende tidsplan."),
                new(
                    "Dataejer",
                    "To dokumenter placerer dataansvaret hos forskellige roller.",
                    "01_Projektcharter_Aurora.docx – side 3 – \"Product Owner er dataejer\"",
                    "05_Dataejerskab_Aurora.pdf – side 2 – \"Data Office skal godkende og overtage dataejerskab\"",
                    "Uklart mandat kan forsinke godkendelser og datamigrering.")
            ],
            MissingDecisions =
            [
                new("Fastlæg én bindende go-live-dato", "Plan, sikkerhedstest og leverandørplan kan ikke baselines før datoen er besluttet.", "02_Projektplan_Aurora.docx / 08_Styregruppereferat_Aurora.txt", "4. september 2026"),
                new("Godkend finansiering af forecast", "Projektet mangler 1,9 mio. kr. i forhold til den godkendte ramme.", "01_Projektcharter_Aurora.docx / 03_Budget_Aurora.xlsx", "7. september 2026"),
                new("Udpeg endelig dataejer", "Ansvar for datakvalitet, accept og migration er uklart.", "05_Dataejerskab_Aurora.pdf", "10. september 2026"),
                new("Beslut sikkerheds-gate for produktion", "Det er uklart, om go-live må ske med åbne kritiske sikkerhedsfund.", "04_Sikkerhed_og_testplan_Aurora.docx", "11. september 2026")
            ],
            Evidence =
            [
                new("02_Projektplan_Aurora.docx – side 4", "Go-live 15. oktober 2026", "Nuværende officielle projektdato"),
                new("08_Styregruppereferat_Aurora.txt – afsnit 3", "Realistisk go-live er 1. november", "Konflikt om tidsplan"),
                new("03_Budget_Aurora.xlsx – Forecast", "Forventet slutforbrug: 13,1 mio. kr.", "Budgetrisiko"),
                new("04_Sikkerhed_og_testplan_Aurora.docx – side 3", "Penetrationstest skal være lukket før produktionssætning", "Sikkerhedsgate"),
                new("06_Leverandorstatus_Aurora.pptx – slide 5", "Første ledige testslot: 23. oktober", "Leverandørafhængighed"),
                new("05_Dataejerskab_Aurora.pdf – side 2", "Data Office skal godkende og overtage dataejerskab", "Uklar dataejer")
            ],
            Actions =
            [
                new() { Id = 1, Title = "Beslut revideret go-live", Description = "Saml styregruppen om én dato og rebaseline plan, kommunikation og ressourcer.", ResponsibleRole = "Styregruppe", Deadline = new DateTime(2026, 9, 4), Priority = "Kritisk", Status = "Ikke startet", Evidence = "Plan + styregruppereferat" },
                new() { Id = 2, Title = "Godkend budgetændring", Description = "Tag stilling til forecast på 13,1 mio. kr. og finansiering af merforbruget.", ResponsibleRole = "Projektejer", Deadline = new DateTime(2026, 9, 7), Priority = "Høj", Status = "Ikke startet", Evidence = "Charter + budget" },
                new() { Id = 3, Title = "Lås sikkerhedstestplan", Description = "Book penetrationstest og fastlæg, at kritiske fund skal lukkes før produktion.", ResponsibleRole = "IT-sikkerhed", Deadline = new DateTime(2026, 9, 11), Priority = "Kritisk", Status = "I gang", Evidence = "Testplan + leverandørstatus" },
                new() { Id = 4, Title = "Udpeg dataejer", Description = "Afklar mandat mellem Product Owner og Data Office og dokumentér beslutningen.", ResponsibleRole = "Programledelse", Deadline = new DateTime(2026, 9, 10), Priority = "Høj", Status = "Afventer", Evidence = "Charter + dataejerskab" },
                new() { Id = 5, Title = "Bekræft leverandørbemanding", Description = "Få navngivne ressourcer og bindende kapacitetsplan for testperioden.", ResponsibleRole = "Projektleder", Deadline = new DateTime(2026, 9, 8), Priority = "Høj", Status = "I gang", Evidence = "Leverandørstatus + risikolog" }
            ],
            Timeline =
            [
                new(new DateTime(2026, 9, 4), "Beslut go-live-dato", "Beslutning", "Manglende", "Styregruppen skal vælge én bindende dato.", "Projektplan / styregruppereferat"),
                new(new DateTime(2026, 9, 7), "Budgetgodkendelse", "Beslutning", "Manglende", "Merforbrug på 1,9 mio. kr. skal finansieres eller reduceres.", "Budget / charter"),
                new(new DateTime(2026, 9, 10), "Dataejer på plads", "Governance", "Manglende", "Dataejer skal have mandat før endelig migreringsaccept.", "Dataejerskabsnotat"),
                new(new DateTime(2026, 9, 11), "Sikkerheds-gate besluttet", "Sikkerhed", "Åben", "Kriterier for produktion med sikkerhedsfund skal fastlægges.", "Testplan"),
                new(new DateTime(2026, 10, 15), "Planlagt go-live", "Milepæl", "I konflikt", "Datoen står fortsat i projektplanen.", "Projektplan"),
                new(new DateTime(2026, 10, 23), "Tidligste penetrationstest", "Test", "Planlagt", "Leverandørens første ledige slot.", "Leverandørstatus"),
                new(new DateTime(2026, 11, 1), "Realistisk go-live", "Milepæl", "Ikke besluttet", "Dato omtalt i seneste styregruppereferat.", "Styregruppereferat")
            ]
        };

        return Task.FromResult(analysis);
    }
}
