# Copy
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy
COPY *.sln .
COPY UserManagementApi/*.csproj ./UserManagementApi/
RUN dotnet restore

# Publish
COPY . .
WORKDIR /src/UserManagementApi
RUN dotnet publish -c Release -o /app/publish

# Build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserManagementApi.dll"]