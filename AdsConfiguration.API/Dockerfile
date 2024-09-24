FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdsConfiguration.API/AdsConfiguration.API.csproj", "AdsConfiguration.API/"]
COPY ["AdsConfiguration.Application/AdsConfiguration.Application.csproj", "AdsConfiguration.Application/"]
COPY ["AdsConfiguration.Data/AdsConfiguration.Data.csproj", "AdsConfiguration.Data/"]
COPY ["AdsConfiguration.Domain/AdsConfiguration.Domain.csproj", "AdsConfiguration.Domain/"]
RUN dotnet restore "AdsConfiguration.API/AdsConfiguration.API.csproj"
COPY . .
WORKDIR "/src/AdsConfiguration.API"
RUN dotnet build "AdsConfiguration.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AdsConfiguration.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdsConfiguration.API.dll"]
