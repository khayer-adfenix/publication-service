FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY ConsumerService/ConsumerService.csproj ConsumerService/
COPY Adfenix.RabbitmqNetCore/Adfenix.RabbitmqNetCore.csproj Adfenix.RabbitmqNetCore/
COPY AdFenix.InfrastructureNetCore/AdFenix.InfrastructureNetCore.csproj AdFenix.InfrastructureNetCore/
RUN dotnet restore
COPY . .
WORKDIR /src/ConsumerService
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConsumerService.dll"]
