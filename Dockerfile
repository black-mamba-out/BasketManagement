#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ./CartManagement/CartManagement.csproj ./CartManagement
COPY ./CartManagement.Business/CartManagement.Business.csproj ./CartManagement.Business/
COPY ./CartManagement.DataLayer/CartManagement.DataLayer.csproj ./CartManagement.DataLayer/
COPY ./CartManagement.Domain/CartManagement.Domain.csproj ./CartManagement.Domain/
RUN dotnet restore "./CartManagement"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./CartManagement" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./CartManagement" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartManagement.dll"]
