FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Smakownia.Identity.Api/Smakownia.Identity.Api.csproj", "src/Smakownia.Identity.Api/"]
COPY ["src/Smakownia.Identity.Application/Smakownia.Identity.Application.csproj", "src/Smakownia.Identity.Application/"]
COPY ["src/Smakownia.Identity.Domain/Smakownia.Identity.Domain.csproj", "src/Smakownia.Identity.Domain/"]
COPY ["src/Smakownia.Identity.Infrastructure/Smakownia.Identity.Infrastructure.csproj", "src/Smakownia.Identity.Infrastructure/"]
RUN dotnet restore "src/Smakownia.Identity.Api/Smakownia.Identity.Api.csproj"
COPY . .
WORKDIR "/src/src/Smakownia.Identity.Api"
RUN dotnet build "Smakownia.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Smakownia.Identity.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smakownia.Identity.Api.dll"]
