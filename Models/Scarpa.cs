namespace ShoppingOnline.Models
{
    public class Scarpa
    {
        public int Id { get; set; }
        public required string Brand { get; set; }
        public decimal Prezzo { get; set; }
        public required string Immagine { get; set; }
        public required string Descrizione { get; set; }

    }

}
