FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["TranslationsService.csproj", "TranslationsService/"]
RUN dotnet restore "TranslationsService/TranslationsService.csproj"

WORKDIR "/src/TranslationsService"
COPY . .
RUN dotnet build "TranslationsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TranslationsService.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslationsService.dll"]
