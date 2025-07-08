# Use a imagem base do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /App

# Copie os arquivos para o container
COPY . ./

# Execute o restore e o build
RUN dotnet restore
RUN dotnet publish -c Release -o out -v detailed

# Use a imagem base do .NET ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /App

# Copie o output do build para o container
COPY --from=build-env /App/out .

ENV ASPNETCORE_URLS=http://+:5027

EXPOSE 5027

# Defina o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "ProjectFinancas.dll"]
