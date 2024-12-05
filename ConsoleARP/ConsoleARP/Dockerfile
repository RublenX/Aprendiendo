# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

# Actualizar los repositorios e instalar net-tools
RUN apt-get update && apt-get install -y net-tools iputils-ping

USER app
WORKDIR /app

# Cambiar al usuario root para la instalación
#USER root

# Actualizar los repositorios e instalar net-tools
#RUN apt-get update && apt-get install -y net-tools

# Cambiar de nuevo al usuario no root si es necesario
#USER app

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsoleARP/ConsoleARP.csproj", "ConsoleARP/"]
RUN dotnet restore "./ConsoleARP/ConsoleARP.csproj"
COPY . .
WORKDIR "/src/ConsoleARP"
RUN dotnet build "./ConsoleARP.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConsoleARP.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleARP.dll"]