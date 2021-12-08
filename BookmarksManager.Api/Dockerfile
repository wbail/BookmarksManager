#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookmarksManager.Api/BookmarksManager.Api.csproj", "BookmarksManager.Api/"]
COPY ["BookmarksManager.App/BookmarksManager.App.csproj", "BookmarksManager.App/"]
COPY ["BookmarksManager.Domain/BookmarksManager.Domain.csproj", "BookmarksManager.Domain/"]
COPY ["BookmarksManager.Infrastructure/BookmarksManager.Infrastructure.csproj", "BookmarksManager.Infrastructure/"]
COPY ["BookmarksManager.Persistence/BookmarksManager.Persistence.csproj", "BookmarksManager.Persistence/"]
RUN dotnet restore "BookmarksManager.Api/BookmarksManager.Api.csproj"
COPY . .
WORKDIR "/src/BookmarksManager.Api"
RUN dotnet build "BookmarksManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookmarksManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookmarksManager.Api.dll"]