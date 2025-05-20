using System.ComponentModel.DataAnnotations;

namespace PeliculasApp.Models
{
    public class PeliculaFavorita
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Año { get; set; }

        public string Poster { get; set; }
    }
}
