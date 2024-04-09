#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TESTING/TESTING.csproj", "TESTING/"]
RUN dotnet restore "TESTING/TESTING.csproj"
COPY . .
WORKDIR "/src/TESTING"
RUN dotnet build "TESTING.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TESTING.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TESTING.dll"]