FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BlocklyPro.Api.csproj", ""]
RUN dotnet restore "./BlocklyPro.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BlocklyPro.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlocklyPro.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlocklyPro.Api.dll"]