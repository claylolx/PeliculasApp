using Newtonsoft.Json;

namespace PeliculasApp.Models
{
    public class PeliculaAPI
    {
        [JsonProperty("Title")]
        public string Titulo { get; set; }

        [JsonProperty("Year")]
        public string Año { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("Plot")]
        public string Sinopsis { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }
    }
}
