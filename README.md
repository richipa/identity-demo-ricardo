# IdentityDemo

Este proyecto es una aplicación web desarrollada como trabajo académico para la asignatura de desarrollo web con ASP.NET Core.

La aplicación utiliza ASP.NET Core MVC junto con Identity para gestionar usuarios, roles y autenticación, y permite a cada usuario gestionar sus propias tareas.

## Funcionalidades principales

- Registro y autenticación de usuarios
- Gestión de roles (Usuario y Admin)
- CRUD de tareas asociado a cada usuario
- Edición y eliminación de tareas propias
- Filtrado de tareas por estado (pendiente, en proceso y completada)
- Perfil de usuario con datos básicos editables
- Panel de administración accesible solo para usuarios con rol Admin

## Tecnologías utilizadas

- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core
- MySQL
- Bootstrap
- HTML y CSS

## Estructura del proyecto

- Controllers: controladores de la aplicación
- Models: modelos de datos
- DTOs: objetos de transferencia de datos
- Services: lógica de negocio
- Datos / Repositorios: acceso a datos
- Views: vistas Razor
- Migrations: migraciones de Entity Framework
- wwwroot: archivos estáticos (CSS, JS)

## Base de datos

La base de datos no se incluye en el repositorio por motivos de seguridad.

Se utiliza Entity Framework Core con migraciones para generar automáticamente la estructura de la base de datos.

Para crear la base de datos en local, se debe ejecutar el siguiente comando desde la raíz del proyecto:

-------------------------
dotnet ef database update
-------------------------

## Configuración

La cadena de conexión se gestiona mediante el archivo `appsettings.json`.  
Los archivos de configuración específicos del entorno de desarrollo no se incluyen en el repositorio.

## Aviso

Este proyecto ha sido desarrollado exclusivamente con fines educativos.  
No se trata de una aplicación en producción ni gestiona datos reales.

