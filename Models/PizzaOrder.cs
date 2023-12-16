namespace ecom.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public PizzaSize Size { get; set; }

    }
}