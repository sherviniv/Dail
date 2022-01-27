#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Dail.WebUI/Dail.WebUI.csproj", "src/Dail.WebUI/"]
COPY ["src/Dail.Application/Dail.Application.csproj", "src/Dail.Application/"]
COPY ["src/Dail.Domain/Dail.Domain.csproj", "src/Dail.Domain/"]
COPY ["src/Dail.Infrastructure/Dail.Infrastructure.csproj", "src/Dail.Infrastructure/"]
RUN dotnet restore "src/Dail.WebUI/Dail.WebUI.csproj"
COPY . .
WORKDIR "/src/src/Dail.WebUI"
RUN dotnet build "Dail.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dail.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dail.WebUI.dll"]
