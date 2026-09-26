## Puesta en marcha

1. Abrí `AppBase.sln` en Visual Studio 2022 (o `dotnet build` desde consola,
   requiere el workload de escritorio de .NET para el proyecto `App`, que es
   `net8.0-windows` + WinForms).
2. Ejecutá en SQL Server, en este orden:
   - `Database/01_CrearBaseDeDatos.sql`
   - `Database/02_DatosIniciales.sql`
3. Ajustá la cadena de conexión `Conexion.cs` en la capa `DAL` con tu servidor.
4. Compilá y ejecutá el proyecto `App`. Iniciá sesión con:

   ```
   Usuario:    admin
   Contraseña: admin123
   ```

   Este usuario tiene la familia de permisos **Admin**, que incluye las 4
   patentes base (gestión de permisos, usuarios, idiomas y backup/restore).
   Cambiá la contraseña o creá tu propio usuario administrador antes de
   pasar a producción.

   En caso de testear el apartado de negocio Inicia sesion con:

   ```
   Usuario:    gestor
   Contraseña: gestor123
   ```