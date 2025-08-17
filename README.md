# ☕ Colombian Coffee App - Desktop App

---

## Herramientas Usadas

![Git Flow](https://img.shields.io/badge/Git%20Flow-FE7A16?logo=git&logoColor=white&style=for-the-badge)![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-FE5196.svg?style=for-the-badge&logo=conventional-commits&logoColor=white)![.NET 9](https://img.shields.io/badge/.NET_9-512BD4.svg?style=for-the-badge&logo=.net&logoColor=white)![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-0078D7.svg?style=for-the-badge&logo=nuget&logoColor=white)![MySQL](https://img.shields.io/badge/MySQL-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white)

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