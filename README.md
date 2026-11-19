# DSWI_T1_03

Proyecto de Servicios Web I desarrollado con ASP.NET Core y .NET 10. La aplicación trabaja con la base de datos `LibreriaBD` mediante Entity Framework Core y SQL Server.

## Requisitos

- .NET 10 SDK
- Visual Studio 2026 o una versión compatible
- SQL Server, SQL Server Express o LocalDB
- La base de datos `LibreriaBD` con sus tablas, datos y procedimientos almacenados

## Configuración

Cada integrante debe utilizar su propia conexión local. El nombre del servidor puede ser diferente en cada ordenador, por ejemplo:

- `localhost`
- `.\SQLEXPRESS`
- `(localdb)\MSSQLLocalDB`
- `NOMBRE_DEL_EQUIPO\SQLEXPRESS`

Desde la carpeta raíz del repositorio, configura la conexión con User Secrets:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=TU_SERVIDOR;Database=LibreriaBD;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True" --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

Si utilizas autenticación SQL Server, puedes usar esta variante:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=TU_SERVIDOR;Database=LibreriaBD;User ID=sa;Password=TU_CONTRASEÑA;MultipleActiveResultSets=True;TrustServerCertificate=True" --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

Para comprobar la configuración:

```powershell
dotnet user-secrets list --project .\DSWI_T1_03\DSWI_T1_03.csproj
```

Cada integrante configura su conexión con User Secrets. No subas `appsettings.Development.json` si contiene el servidor de tu equipo o credenciales. En entorno `Development`, User Secrets tiene prioridad sobre los archivos `appsettings`.

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
