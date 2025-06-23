using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Models
{
    public class CatalogoScarpe
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Marca { get; set; }

        public string? Descrizione { get; set; }

        [Range(0, 9999)]
        public decimal Price { get; set; }

        public string? ImmagineUrl { get; set; }
    }
}
