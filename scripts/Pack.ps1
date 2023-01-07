# Clear previous published content
Remove-Item -Path ../publish/* -Recurse -Force

dotnet pack -c Release -o ../publish "../src/RolandK.Formats.Gpx.sln"  /p:ContinuousIntegrationBuild=true /p:IncludeSymbols=true /p:EmbedUntrackedSources=true -p:SymbolPackageFormat=snupkg