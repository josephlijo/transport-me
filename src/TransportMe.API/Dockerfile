FROM microsoft/aspnetcore:2.1-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.1-nanoserver-1709 AS build
WORKDIR /src
COPY TransportMe.API.sln ./
COPY TransportMe.API/TransportMe.API.csproj TransportMe.API/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/TransportMe.API
RUN dotnet build TransportMe.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TransportMe.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TransportMe.API.dll"]
