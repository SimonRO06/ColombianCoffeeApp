# ☕ Colombian Coffee App - Desktop App

---

### 🛠️ Tecnologías y Herramientas

![Python](https://img.shields.io/badge/Python-3776AB?style=for-the-badge&logo=python&logoColor=white)  
![HTML](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)  
![CSS](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)  
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)  
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)  
![Git Flow](https://img.shields.io/badge/Git%20Flow-FF7F50?style=for-the-badge&logo=git&logoColor=white)  
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)  
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)  
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)  
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)  
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-68217A?style=for-the-badge&logo=dotnet&logoColor=white)  

---

## 📖 Descripcion del Programa 

Colombian Coffee App es una aplicacion creada para almacenar y gestionar un registro detallado de las variedades de café deseados. La aplicacion permite filtrar por diferentes atributos agronómicos y resistencias a enfermedades.

La aplicación cuenta con dos interfaces:

### 🙋 Administradores 
Pueden agregar, eliminar y modificar tanto las variedades de café como los usuarios registrados.

### 👤 Usuarios Estándar 
Pueden explorar las variedades disponibles, filtrarlas según sus preferencias y generar un catálogo PDF personalizado.

---

## 📦 Instalacion de Paquetes 

```bash
dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-rc.1.efcore.9.0.0

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.Extensions.Configuration

dotnet add package Microsoft.Extensions.Configuration.Json

dotnet add package Microsoft.Extensions.Configuration.EnvironmentVariables

dotnet add package itext7

dotnet add package itext.bouncy-castle-adapter
```

---

## ⚙️ Setup de la Base de Datos 

### Utilizando Migraciones:
```
dotnet ef migrations add InitialCreate
dotnet ef database update

```

### Manual:
```sql
CREATE DATABASE ColombianCoffeeApp;

USE ColombianCoffeeApp;

CREATE TABLE usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(255) NULL,
    Contrasena VARCHAR(255) NULL,
    Rol VARCHAR(20) NOT NULL
);

CREATE TABLE variedad (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreComun VARCHAR(100) NOT NULL,
    Descripcion TEXT NOT NULL,
    NombreCientifico VARCHAR(150) NOT NULL,
    RutaImagen VARCHAR(255) NOT NULL,
    Porte VARCHAR(20) NOT NULL,
    TamanoGrano VARCHAR(20) NOT NULL,
    AltitudOptima INT NOT NULL,
    Rendimiento VARCHAR(20) NOT NULL,
    CalidadGrano INT NOT NULL,
    ResistenciaRoya VARCHAR(20) NOT NULL,
    ResistenciaAntracnosis VARCHAR(20) NOT NULL,
    ResistenciaNematodos VARCHAR(20) NOT NULL,
    TiempoCosecha VARCHAR(50) NOT NULL,
    TiempoMaduracion VARCHAR(50) NOT NULL,
    RecomendacionNutricion TEXT NOT NULL,
    DensidadSiembra VARCHAR(50) NOT NULL,
    Historia TEXT NOT NULL,
    GrupoGenetico VARCHAR(100) NOT NULL,
    Obtentor VARCHAR(100) NOT NULL,
    Familia VARCHAR(100) NOT NULL
);
```

---

## 👥 Desarrolladores

- [**Simón Rubiano Ortiz**](https://github.com/SimonRO06) - Encargado de la asignacion de tareas y apoyo en la realizacion de estas.

- [**Fabio Andres Hernandez Manrique**](https://github.com/fabioo-hm) - Encargado del desarrollo y conexion con la base de datos.

- [**Andres Suarez Niño**](https://github.com/andresn1906) - Encargado de la creacion de los menus e interfaces.

- [**Juan Sebastian Mora Patiño**](https://github.com/sebastian221-art) - Encargado de la creacion del PDF.
