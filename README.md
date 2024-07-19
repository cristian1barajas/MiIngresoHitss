# MiIngresoHitss

MiIngresoHitssApp es una aplicación ASP.NET Core MVC que simula un sistema de gestión de productos, clientes y ventas. La aplicación incluye funcionalidades de carrito de compras y generación de reportes de ventas en un rango de fechas.

## Características

- Gestión de productos (CRUD).
- Gestión de clientes (CRUD).
- Gestión de listas de precios (CRUD).
- Gestión de ventas (CRUD).
- Carrito de compras.
- Generación de reportes de ventas en un rango de fechas.

## Requisitos

- .NET 6.0 o superior
- Visual Studio 2022 o superior
- SQL Server 2019 o superior
- IIS para la publicación

## Instalación

1. Clona el repositorio:
    ```bash
    git clone https://github.com/tu-usuario/MiIngresoHitssApp.git
    cd MiIngresoHitssApp
    ```

2. Configura la cadena de conexión a la base de datos en `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=tu-servidor;Database=MiIngresoHitss;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```

3. Restaura los paquetes NuGet y construye el proyecto:
    ```bash
    dotnet restore
    dotnet build
    ```

4. Aplica las migraciones a la base de datos:
    ```bash
    dotnet ef database update
    ```

5. Ejecuta la aplicación:
    ```bash
    dotnet run
    ```

## Instalación Base de Datos

1. Descargar los script de la carpeta Script_DB del repositorio.
2. Ejecuta primero el script CREATE_DATABASE.sql
3. Puedes ejecutar en cualquier orden el resto de scripts.

## Publicación

Para publicar la aplicación en IIS:

1. Abre el proyecto en Visual Studio.
2. Haz clic derecho en el proyecto y selecciona **Publicar**.
3. Selecciona **IIS, FTP, etc.** como destino.
4. Configura el perfil de publicación y selecciona la carpeta de destino (`C:\inetpub\wwwroot\MiIngresoHitssApp`).
5. Publica la aplicación.

## Uso

### Carrito de Compras

1. Navega a la página de productos.
2. Haz clic en el botón "Agregar al Carrito" para agregar productos al carrito.
3. Navega al carrito de compras para ver los productos agregados.
4. Desde el carrito, puedes eliminar productos o proceder con la compra.

### Reportes de Ventas

1. Navega a la página de reportes de ventas.
2. Selecciona un rango de fechas y genera el reporte.

## Estructura del Proyecto

- `Controllers`: Contiene los controladores de la aplicación.
- `Models`: Contiene los modelos de datos.
- `Views`: Contiene las vistas Razor.
- `wwwroot`: Contiene archivos estáticos como CSS, JS e imágenes.

## Contribución

1. Haz un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y commitea (`git commit -m 'Agrega nueva funcionalidad'`).
4. Haz push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.
