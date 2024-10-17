# Usar a imagem do SDK do .NET 8.0 para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo de solução e restaurar dependências
COPY *.sln .
COPY UserManagementApi/*.csproj ./UserManagementApi/
RUN dotnet restore

# Copiar o restante do código e compilar a aplicação
COPY . .
WORKDIR /src/UserManagementApi
RUN dotnet publish -c Release -o /app/publish

# Usar a imagem do runtime do .NET 8.0 para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserManagementApi.dll"]