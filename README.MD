# 🎬 PeliculasApp – Proyecto Final MP3B/MP9 UF3

Aplicación web desarrollada con ASP.NET Core MVC que permite buscar películas usando la API pública de OMDb, ver sus detalles y guardarlas como favoritas en una base de datos local (SQLite). Este proyecto forma parte de la UF3 de los módulos MP03B (Programación orientada a objetos) y MP09 (Interfaces gráficas).

---

## ✅ Justificación y motivación del proyecto

El objetivo principal de esta aplicación es poner en práctica los conocimientos adquiridos durante el curso en desarrollo web con .NET Core MVC. Se ha escogido el tema del cine por su atractivo visual, facilidad de uso de datos públicos mediante API, y por ser una temática con gran aceptación entre los usuarios.

- El patrón Modelo-Vista-Controlador (MVC)
- La programación orientada a objetos
- El consumo de APIs externas con formato JSON
- El uso de Entity Framework Core con SQLite
- La maquetación con Razor Pages, HTML y CSS
- La validación básica de formularios
- Principios de accesibilidad (validado con Wave)

---

## 💻 Explicación detallada del código desarrollado (MVC)

### 📁 MODELS

- **PeliculaAPI.cs**: Representa una película recibida desde OMDb API (título, año, póster, sinopsis).
- **PeliculaFavorita.cs**: Modelo usado para guardar películas favoritas en la base de datos SQLite.
- **AppDbContext.cs**: Contexto de Entity Framework Core. Define el `DbSet` para la tabla de películas favoritas.

### 🎮 CONTROLLERS

- **PeliculasController.cs**:
  - `Index()`: Muestra un formulario de búsqueda y una lista por defecto de películas populares.
  - `Buscar(titulo)`: Realiza una llamada a la OMDb API y muestra la película encontrada.
  - `GuardarFavorito(pelicula)`: Guarda una película seleccionada en la base de datos local.
  - `Favoritos()`: Lista las películas favoritas guardadas.
  - `EliminarFavorito(id)`: Elimina una película favorita de la base de datos.

### 🖼️ VIEWS

- **Index.cshtml**: Muestra el buscador y películas por defecto con estilos visuales modernos.
- **Resultado.cshtml**: Muestra detalles de la película seleccionada desde la API.
- **Favoritos.cshtml**: Muestra las películas favoritas guardadas con opción de eliminar.
- **_Layout.cshtml**: Contiene el menú superior y el diseño base de todas las páginas.

---

## 🛠️ Propuestas de mejora y nuevas funcionalidades

- Añadir autenticación de usuarios con roles y login.
- Hacer que cada usuario tenga su propia lista de favoritos.
- Agregar filtros por género, director o año.
- Implementar paginación en resultados.
- Hacer diseño completamente responsive
- Permitir valoración o puntuación de películas.
- Exportar favoritos a PDF o CSV.

---
