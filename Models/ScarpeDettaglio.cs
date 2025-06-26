using Microsoft.Identity.Client;

namespace ShoppingOnline.Models
{

    public class DettaglioScarpaViewModel
    {
        public CatalogoScarpe Scarpa { get; set; } = default!;
        public List<TagliaScarpa>TaglieDisponibili { get; set; } = new();

        public List<CatalogoScarpe> AltreProposte { get; set; } = new();
    }

}