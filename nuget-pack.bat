
dotnet build .\Voodoo.Patterns\Voodoo.Patterns.csproj --configuration Release
nuget pack  .\voodoo.reports\voodoo.reports.nuspec
nuget pack  .\voodoo.reports\voodoo.reports.symbols.nuspec -Symbols 
dir