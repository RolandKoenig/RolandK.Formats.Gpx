# Clear previous artifacts
if (Test-Path "../publish")
{
	"Clearing ../publ�sh"
	Remove-Item -Path "../publish/*" -Recurse -Force;
}

# Build nuget packages
dotnet pack -c Release -o ../publish "../RolandK.Formats.Gpx.sln"  /p:ContinuousIntegrationBuild=true /p:IncludeSymbols=true /p:EmbedUntrackedSources=true -p:SymbolPackageFormat=snupkg