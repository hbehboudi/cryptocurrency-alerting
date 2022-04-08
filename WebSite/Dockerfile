#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EndPoint.Site/EndPoint.Site.csproj", "EndPoint.Site/"]
COPY ["WebSite.Persistence/WebSite.Persistence.csproj", "WebSite.Persistence/"]
COPY ["WebSite.Application/WebSite.Application.csproj", "WebSite.Application/"]
COPY ["WebSite.Common/WebSite.Common.csproj", "WebSite.Common/"]
COPY ["WebSite.Domain/WebSite.Domain.csproj", "WebSite.Domain/"]
RUN dotnet restore "EndPoint.Site/EndPoint.Site.csproj"
COPY . .
WORKDIR "/src/EndPoint.Site"
RUN dotnet build "EndPoint.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EndPoint.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EndPoint.Site.dll"]