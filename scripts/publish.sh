dotnet restore
dotnet publish -p:PublishProfile="TemplateAppGenerator/Properties/PublishProfiles/DefaultPublish.pubxml" \
"TemplateAppGenerator/TemplateAppGenerator.csproj"
