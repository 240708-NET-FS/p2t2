FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY PawsonalityApp.API /app/PawsonalityApp.API

# Run donet publish to make the artifact
RUN dotnet publish PawsonalityApp.API -c Release -o out

# Start a new layer from .NET 8 runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

ENV ASPNETCORE_URLS http://*:80

WORKDIR /app

COPY --from=build /app/out .

CMD ["dotnet", "PawsonalityApp.API.dll"]
