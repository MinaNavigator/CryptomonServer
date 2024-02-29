# CryptomonServer

Game server for my mina game

# Deploy locally

Install postgreSQL

Create a database with the name cryptomon

Update the connection strings information in appsettings.json

## Add migration

dotnet tool install --global dotnet-ef

cd CryptomonServer

dotnet ef migrations add MigrationName

dotnet ef database update
