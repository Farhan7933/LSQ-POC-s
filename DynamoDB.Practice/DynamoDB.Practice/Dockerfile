#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DynamoDB.Practice/DynamoDB.Practice.csproj", "DynamoDB.Practice/"]
RUN dotnet restore "DynamoDB.Practice/DynamoDB.Practice.csproj"
COPY . .
WORKDIR "/src/DynamoDB.Practice"
RUN dotnet build "DynamoDB.Practice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DynamoDB.Practice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DynamoDB.Practice.dll"]