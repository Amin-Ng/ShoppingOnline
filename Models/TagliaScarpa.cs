using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.Models
{
    public class TagliaScarpa
    {
        [Key]
        public int Id { get; set; }

        public int Taglia { get; set; }

        public int Quantita { get; set; }

        public int CatalogoScarpaId { get; set; }
        public CatalogoScarpe CatalogoScarpa{ get; set; } = default!;



    }
}
