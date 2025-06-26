using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingOnline.Models
{
    public class CatalogoScarpe
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; } = default!;

        [Required]
        public string? Marca { get; set; } = default!;

        public string? Descrizione { get; set; }

        [Range(0, 9999)]
        public decimal Price { get; set; }

        public string? ImmagineUrl { get; set; }

        [JsonPropertyName("TaglieDisponibili")]
        public List<TagliaScarpa>? tagliaScarpa { get; set; }



    }
}
