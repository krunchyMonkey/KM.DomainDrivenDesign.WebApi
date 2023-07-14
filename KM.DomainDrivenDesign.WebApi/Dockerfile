#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KM.DomainDrivenDesign.WebApi/KM.DomainDrivenDesign.WebApi.csproj", "KM.DomainDrivenDesign.WebApi/"]
RUN dotnet restore "KM.DomainDrivenDesign.WebApi/KM.DomainDrivenDesign.WebApi.csproj"
COPY . .
WORKDIR "/src/KM.DomainDrivenDesign.WebApi"
RUN dotnet build "KM.DomainDrivenDesign.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KM.DomainDrivenDesign.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KM.DomainDrivenDesign.WebApi.dll"]