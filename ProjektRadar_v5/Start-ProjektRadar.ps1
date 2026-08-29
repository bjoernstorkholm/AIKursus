$ErrorActionPreference = "Stop"

$dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
if (-not $dotnet) {
    Write-Host "ProjektRadar kræver .NET 10 SDK." -ForegroundColor Yellow
    Write-Host "Installer .NET 10 SDK fra Microsoft og kør denne fil igen."
    exit 1
}

$sdk10 = dotnet --list-sdks | Select-String -Pattern '^10\.'
if (-not $sdk10) {
    Write-Host "ProjektRadar kræver .NET 10 SDK, men ingen .NET 10 SDK blev fundet." -ForegroundColor Yellow
    Write-Host "Installer .NET 10 SDK og kør denne fil igen."
    exit 1
}

Set-Location $PSScriptRoot
Write-Host "Starter ProjektRadar på .NET 10..." -ForegroundColor Cyan
Write-Host "Når appen er startet, åbn den adresse som dotnet run viser i terminalen." -ForegroundColor DarkGray

dotnet restore
dotnet run
