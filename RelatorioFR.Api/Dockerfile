#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RelatorioFR.Api/RelatorioFR.Api.csproj", "RelatorioFR.Api/"]
RUN dotnet restore "RelatorioFR.Api/RelatorioFR.Api.csproj"
COPY . .
WORKDIR "/src/RelatorioFR.Api"
RUN dotnet build "RelatorioFR.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RelatorioFR.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RelatorioFR.Api.dll"]