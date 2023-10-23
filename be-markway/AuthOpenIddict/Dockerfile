#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

RUN apt-get update -y
RUN apt-get install -y iputils-ping

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuthOpenIddict/AuthOpenIddict.csproj", "AuthOpenIddict/"]
COPY ["Commons/Commons.csproj", "Commons/"]
RUN dotnet restore "AuthOpenIddict/AuthOpenIddict.csproj"
COPY . .
WORKDIR "/src/AuthOpenIddict"
RUN dotnet build "AuthOpenIddict.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthOpenIddict.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AuthOpenIddict.dll"]
