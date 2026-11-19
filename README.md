# DSWI_T1_03

Proyecto de Servicios Web I desarrollado con ASP.NET Core y .NET 10. La aplicación trabaja con la base de datos `LibreriaBD` mediante Entity Framework Core y SQL Server.

## Requisitos

- .NET 10 SDK
- Visual Studio 2026 o una versión compatible
- SQL Server, SQL Server Express o LocalDB
- La base de datos `LibreriaBD` con sus tablas, datos y procedimientos almacenados

## Configuración

Cada integrante conecta la aplicación a su propia instancia local de SQL Server. `ConnectionStrings:DefaultConnection` es el nombre fijo de la configuración; no es una contraseña. El valor de `TU_SERVIDOR` debe reemplazarse por el nombre que aparece en el campo **Nombre del servidor** de SSMS.

Por ejemplo, si tu instancia local es SQL Server Express y en SSMS aparece como `TU_EQUIPO\SQLEXPRESS`, puedes usar `.` para referirte a tu propio equipo:

Desde la carpeta raíz del repositorio, configura User Secrets con autenticación de Windows:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=LibreriaBD;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True" --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

Si tu instancia tiene otro nombre, sustituye `.` y `SQLEXPRESS` por el servidor y la instancia que usas en SSMS. Si te conectas con usuario y contraseña de SQL Server en lugar de autenticación de Windows, utiliza tus propios datos en esta variante:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=TU_SERVIDOR;Database=LibreriaBD;User ID=sa;Password=TU_CONTRASEÑA;MultipleActiveResultSets=True;TrustServerCertificate=True" --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

Para comprobar que guardaste la configuración:

```powershell
dotnet user-secrets list --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

User Secrets guarda la conexión solo en tu equipo y no se sube a Git. El proyecto ya está preparado para usarlos, así que no hace falta ejecutar `dotnet user-secrets init`. No compartas la salida de `dotnet user-secrets list`, porque puede mostrar tu contraseña. En entorno `Development`, User Secrets tiene prioridad sobre los archivos `appsettings`; no subas `appsettings.Development.json` si contiene el servidor de tu equipo o credenciales.

## Ejecutar el proyecto

```powershell
dotnet restore
dotnet build
dotnet run --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

También se puede abrir la solución `DSWI_T1_03.slnx` desde Visual Studio y ejecutar el proyecto con el perfil de desarrollo.

## Estructura principal

```text
DSWI_T1_03/
├── Controllers/       Controladores de la aplicación
├── Data/              Contextos de Entity Framework Core
├── Models/            Entidades generadas desde la base de datos
├── Repositories/      Repositorios de acceso a datos
├── Services/          Servicios de la aplicación
├── Views/             Vistas Razor
├── Program.cs         Configuración y arranque de la aplicación
└── appsettings.json   Configuración general sin credenciales
```

## Trabajo en equipo

Antes de empezar a trabajar:

```powershell
git pull
```

Cada integrante debe tener una copia local de `LibreriaBD` con la misma estructura. Las conexiones y contraseñas no deben subirse al repositorio ni compartirse en el grupo.
