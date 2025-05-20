using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeliculasApp.Models;
using PeliculasApp.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace PeliculasApp.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly string apiKey = "ae0ce0df";
        private readonly AppDbContext _context;

        // Inyección del DbContext
        public PeliculasController(AppDbContext context)
        {
            _context = context;
        }

        // Vista inicial con formulario
        public async Task<IActionResult> Index()
        {
            var titulos = new List<string> { "Inception", "The Matrix", "Interstellar", "Gladiator" };
            var peliculas = new List<PeliculaAPI>();

            using (HttpClient client = new HttpClient())
            {
                foreach (var titulo in titulos)
                {
                    string url = $"http://www.omdbapi.com/?t={titulo}&apikey={apiKey}";
                    var respuesta = await client.GetStringAsync(url);
                    var pelicula = JsonConvert.DeserializeObject<PeliculaAPI>(respuesta);
                    if (pelicula != null && pelicula.Titulo != null)
                        peliculas.Add(pelicula);
                }
            }

            return View(peliculas);
        }

        // Buscar película por título en la API
        [HttpPost]
        public async Task<IActionResult> Buscar(string titulo)
        {
            if (string.IsNullOrEmpty(titulo))
                return View("Index");

            string url = $"http://www.omdbapi.com/?t={titulo}&apikey={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.GetStringAsync(url);
                var pelicula = JsonConvert.DeserializeObject<PeliculaAPI>(respuesta);

                return View("Resultado", pelicula);
            }
        }

        // Guardar película como favorita
        [HttpPost]
        public IActionResult GuardarFavorito(PeliculaAPI pelicula)
        {
            var favorito = new PeliculaFavorita
            {
                Titulo = pelicula.Titulo,
                Año = pelicula.Año,
                Poster = pelicula.Poster
            };

            _context.PeliculasFavoritas.Add(favorito);
            _context.SaveChanges();

            return RedirectToAction("Favoritos");
        }

        // Mostrar películas favoritas
        public IActionResult Favoritos()
        {
            var favoritos = _context.PeliculasFavoritas.ToList();
            return View(favoritos);
        }

        [HttpPost]
        public IActionResult EliminarFavorito(int id)
        {
            var favorito = _context.PeliculasFavoritas.FirstOrDefault(p => p.Id == id);
            if (favorito != null)
            {
                _context.PeliculasFavoritas.Remove(favorito);
                _context.SaveChanges();
            }
            return RedirectToAction("Favoritos");
        }
    }
}
