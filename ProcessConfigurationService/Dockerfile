FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ProcessConfigurationService.csproj", "ProcessConfigurationService/"]
RUN dotnet restore "ProcessConfigurationService/ProcessConfigurationService.csproj"

WORKDIR "/src/ProcessConfigurationService"
COPY . .
RUN dotnet build "ProcessConfigurationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProcessConfigurationService.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProcessConfigurationService.dll"]
