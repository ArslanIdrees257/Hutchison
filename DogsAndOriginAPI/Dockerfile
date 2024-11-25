#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["/DogsAndOriginAPI.csproj", "DogsAndOriginAPI/"]
RUN dotnet restore "/DogsAndOriginAPI.csproj"
COPY . .
WORKDIR "/src/DogsAndOriginAPI"
RUN dotnet build "DogsAndOriginAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DogsAndOriginAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DogsAndOriginAPI.dll"]
