#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

RUN apt-get update -y
RUN apt-get install -y iputils-ping
RUN apt-get --yes install curl

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Users/Users.API/Users.API.csproj", "Users/Users.API/"]
COPY ["Commons/Commons.csproj", "Commons/"]
RUN dotnet restore "Users/Users.API/Users.API.csproj"
COPY . .
WORKDIR "/src/Users/Users.API"
RUN dotnet build "Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Users.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

HEALTHCHECK --interval=5s --timeout=10s --retries=5 CMD curl --fail http://users.api:5387/health || exit 1

ENTRYPOINT ["dotnet", "Users.dll"]
