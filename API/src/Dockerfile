FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CatMash.Api/CatMash.Api.csproj", "CatMash.Api/"]
COPY ["CatMash.Domain.Business/CatMash.Domain.Business.csproj", "CatMash.Domain.Business/"]
COPY ["CatMash.Domain.Entities/CatMash.Domain.Entities.csproj", "CatMash.Domain.Entities/"]
COPY ["CatMash.Domain.Interface/CatMash.Domain.Interface.csproj", "CatMash.Domain.Interface/"]
COPY ["CatMash.Infrastructure.Common/CatMash.Infrastructure.Common.csproj", "CatMash.Infrastructure.Common/"]
COPY ["CatMash.Infrastructure.Data/CatMash.Infrastructure.Data.csproj", "CatMash.Infrastructure.Data/"]
RUN dotnet restore "CatMash.Api/CatMash.Api.csproj"
WORKDIR "/src"
COPY . .
RUN dotnet build "CatMash.Api/CatMash.Api.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "CatMash.Api/CatMash.Api.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CatMash.Api.dll