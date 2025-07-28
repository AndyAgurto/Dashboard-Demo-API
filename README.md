# Dashboard Demo API

Este proyecto es una API de demostración para un dashboard, desarrollada en .NET 8.0. Proporciona endpoints para obtener datos de ejemplo que pueden ser utilizados en aplicaciones de visualización o paneles de control.

## Características
- API RESTful construida con ASP.NET Core
- Endpoints para obtener datos de dashboard
- Estructura sencilla y fácil de extender

## Estructura del Proyecto
- `Controllers/`: Controladores de la API (por ejemplo, `DashboardController.cs`)
- `Models/`: Modelos de datos utilizados por la API (por ejemplo, `DashboardData.cs`)
- `Program.cs`: Punto de entrada de la aplicación
- `appsettings.json`: Configuración general de la aplicación
- `appsettings.Development.json`: Configuración específica para desarrollo

## Requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Ejecución del Proyecto
1. Clona este repositorio.
2. Abre una terminal en la raíz del proyecto.
3. Ejecuta el siguiente comando para restaurar dependencias:
   ```powershell
   dotnet restore
   ```
4. Ejecuta el proyecto:
   ```powershell
   dotnet run
   ```
5. La API estará disponible en `https://localhost:5001` o `http://localhost:5000` por defecto.

## Pruebas de la API
Puedes probar los endpoints utilizando herramientas como [Postman](https://www.postman.com/) o [curl](https://curl.se/). También puedes usar el archivo `dashboard-demo-api.http` incluido para realizar pruebas rápidas desde VS Code.

## Estructura de Endpoints
Consulta el controlador `DashboardController.cs` para ver los endpoints disponibles y su documentación.

## Contribución
Las contribuciones son bienvenidas. Por favor, abre un issue o pull request para sugerencias o mejoras.

## Autor y Licencia
Autor: Andy Agurto Urcia
Empresa: DEVELOPERS AAU // devopsolutionsa@gmail.com
Licencia: Propietario, uso interno.