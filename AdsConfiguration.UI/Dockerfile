FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdsConfiguration.UI/AdsConfiguration.UI.csproj", "AdsConfiguration.UI/"]
RUN dotnet restore "AdsConfiguration.UI/AdsConfiguration.UI.csproj"
COPY . .
WORKDIR "/src/AdsConfiguration.UI"
RUN dotnet build "AdsConfiguration.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AdsConfiguration.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdsConfiguration.UI.dll"]
