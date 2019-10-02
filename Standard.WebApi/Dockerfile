FROM registry.standard.com.br/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Standard.WebApi/NuGet/NuGet.config ./
COPY Standard.WebApi/Standard.WebApi.csproj Standard.WebApi/
RUN dotnet restore Standard.WebApi/Standard.WebApi.csproj

COPY . .
WORKDIR /src/Standard.WebApi
RUN dotnet build Standard.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Standard.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Standard.WebApi.dll"]