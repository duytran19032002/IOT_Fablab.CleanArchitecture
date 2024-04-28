#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IOT.Api/IOT.Api.csproj", "IOT.Api/"]
COPY ["IOT.Application/IOT.Application.csproj", "IOT.Application/"]
COPY ["IOT.Domain/IOT.Domain.csproj", "IOT.Domain/"]
COPY ["IOT.Infastructure/IOT.Infastructure.csproj", "IOT.Infastructure/"]
COPY ["IOT.Persistence/IOT.Persistence.csproj", "IOT.Persistence/"]
RUN dotnet restore "./IOT.Api/IOT.Api.csproj"
COPY . .
WORKDIR "/src/IOT.Api"
RUN dotnet build "./IOT.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IOT.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IOT.Api.dll"]