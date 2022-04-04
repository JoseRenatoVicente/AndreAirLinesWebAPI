#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AndreAirLines.API/AndreAirLines.API.csproj", "AndreAirLines.API/"]
COPY ["AndreAirLines.Application/AndreAirLines.Application.csproj", "AndreAirLines.Application/"]
COPY ["AndreAirLines.Infra.Data/AndreAirLines.Infra.Data.csproj", "AndreAirLines.Infra.Data/"]
COPY ["AndreAirLines.Domain/AndreAirLines.Domain.csproj", "AndreAirLines.Domain/"]
RUN dotnet restore "AndreAirLines.API/AndreAirLines.API.csproj"
COPY . .
WORKDIR "/src/AndreAirLines.API"
RUN dotnet build "AndreAirLines.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AndreAirLines.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AndreAirLines.API.dll"]