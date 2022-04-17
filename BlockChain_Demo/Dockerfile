#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BlockChain_Demo.csproj", ""]
RUN dotnet restore "./BlockChain_Demo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BlockChain_Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlockChain_Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlockChain_Demo.dll"]