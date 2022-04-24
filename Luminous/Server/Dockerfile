#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Luminous/Server/Luminous.Server.csproj", "Luminous/Server/"]
COPY ["Luminous/Domain/Luminous.Domain.csproj", "Luminous/Domain/"]
COPY ["Luminous/Client/Luminous.Client.csproj", "Luminous/Client/"]
COPY ["Luminous/Shared/Luminous.Shared.csproj", "Luminous/Shared/"]
COPY ["Luminous/Infrastructure/Luminous.Infrastructure.csproj", "Luminous/Infrastructure/"]
RUN dotnet restore "Luminous/Server/Luminous.Server.csproj"
COPY . .
WORKDIR "/src/Luminous/Server"
RUN dotnet build "Luminous.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luminous.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Luminous.Server.dll"]