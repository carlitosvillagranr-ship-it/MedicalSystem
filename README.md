# Sistema CRUD Hospital

## Descripción
El proyecto es una aplicación desarrollada en **C# utilizando el entorno de Visual Studio**. Este sistema está diseñado para gestionar datos relacionados con especialidades médicas, médicos, pacientes, y estados civiles, ofreciendo una interfaz gráfica para administrar la información de manera eficiente.

## Características
- Gestión de especialidades médicas.
- Registro y administración de médicos.
- Manejo de datos de pacientes.
- Control de estados civiles.
- Interfaz gráfica amigable y personalizable.
- Conexión con base de datos mediante un archivo SQL incluido.

## Estructura del Proyecto
### Archivos principales:
- **`App.config`**: Configuración de la aplicación.
- **`MenuPrincipal.cs`**: Punto de entrada del sistema y diseño de la interfaz principal.
- **`CatalogoEspecialidades_SMH.cs`**, **`CatalogoMedicos_SMH.cs`**, **`CatalogoPacientes.cs`**, **`CatalogoEstadoCivil_SMH.cs`**: Módulos para gestionar diferentes catálogos.
- **`Conexion_SMH.cs`**: Configuración de la conexión con la base de datos.

### Recursos:
- Imágenes para la interfaz: `fondo_registro.jpg`, `IMG_edoCivil.jpg`, `IMG_MEDICO.jpg`.
- Íconos: `pencil.ico`.

### Base de datos:
- **`BASE DE DATOS UNIDAD 3.sql`**: Script para crear y configurar la base de datos.

### Otros:
- **`DSDPRN3_SMH_2302B1.sln`** y **`DSDPRN3_SMH_2302B1.csproj`**: Archivos de solución y proyecto para Visual Studio.
- Carpetas como `bin` y `obj` para archivos compilados y temporales.

## Instalación y Configuración
1. Clona este repositorio:
   ```bash
   git clone https://github.com/tu_usuario/DSDPRN3_SMH_2302B1.git
   ```
2. Abre la solución en Visual Studio (`DSDPRN3_SMH_2302B1.sln`).
3. Restaura los paquetes NuGet si es necesario:
   ```bash
   nuget restore
   ```
4. Configura la base de datos:
   - Importa el archivo `BASE DE DATOS UNIDAD 3.sql` a tu gestor de bases de datos.
   - Actualiza la cadena de conexión en `App.config` si es necesario.
5. Ejecuta el proyecto desde Visual Studio.

## Requisitos del Sistema
- **Sistema operativo**: Windows 10 o superior.
- **Entorno de desarrollo**: Visual Studio 2019 o superior.
- **Base de datos**: SQL Server.
- **.NET Framework**: Versión 4.7.2 o superior.

## Implementación de CRUD
El proyecto utiliza el objeto `MySql.DataAdapter` para facilitar la comunicación entre la aplicación y la base de datos. Se implementan las siguientes operaciones CRUD:

### Crear
- Captura datos de un formulario de entrada.
- Valida campos obligatorios antes de insertar los datos en la base de datos.
- Utiliza parámetros para protegerse contra ataques SQL Injection.

### Leer
- Carga los datos desde la base de datos en un `DataGridView`.
- Usa un método llamado `CargarDatosEnDataGridView` que emplea un `MySqlDataAdapter` para rellenar un `DataTable` con los datos recuperados.

### Actualizar
- Permite modificar registros existentes.
- Valida entradas y utiliza consultas parametrizadas para actualizar datos en la base de datos.
- Refresca automáticamente el `DataGridView` tras una actualización exitosa.

### Eliminar
- Elimina registros seleccionados en un `DataGridView`.
- Maneja excepciones con bloques `try-catch`.
- Proporciona retroalimentación al usuario sobre el éxito o fracaso de la operación.

## Estructura de los Catálogos
### Catálogo Estado Civil
- **Alta**: Guarda nuevos registros.
- **Baja**: Elimina registros existentes.
- **Cambio**: Modifica registros existentes.
- **Visualización**: Muestra datos en un `DataGridView`.

### Catálogo Médicos
- **Alta**: Registra nuevos médicos.
- **Baja**: Elimina médicos seleccionados.
- **Cambio**: Permite modificar datos de médicos.
- **Visualización**: Muestra información en un `DataGridView`.

### Catálogo Especialidades
- **Alta**: Guarda nuevas especialidades médicas.
- **Baja**: Elimina especialidades.
- **Cambio**: Modifica especialidades existentes.
- **Visualización**: Presenta datos en un `DataGridView`.

## Liga del Video Explicativo
Puedes acceder al video explicativo a través del siguiente enlace:
[Video Explicativo](https://unadmex-my.sharepoint.com/:v:/g/personal/sergiohernandezunadm08_nube_unadmexico_mx/EVkBxFilkuxFh-3vF_ijrpQBXj6KObnESvH6v7KBuEq7eA?nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0RpcmVjdCJ9fQ&e=Xe3oif)

## Conclusiones
El uso del objeto `MySql.DataAdapter` permite:
- Simplificar la interacción con bases de datos.
- Mejorar la seguridad al utilizar parámetros en las consultas.
- Optimizar el rendimiento al manejar datos en memoria mediante `DataSet`.
- Incrementar la productividad del desarrollador.

### Autor
Sergio Meneses Hernández
## Referencias
- [MySql.DataAdapter Documentación](https://dev.mysql.com/doc/dev/connector-net/latest/api/data_api/MySql.Data.MySqlClient.MySqlDataAdapter.html)
- [Introducción a MySQLConnector/NET](https://dev.mysql.com/doc/connector-net/en/connector-net-introduction.html)
- Pressman, R. (2011). Ingeniería de software: Un enfoque práctico.
