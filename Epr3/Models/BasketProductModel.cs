namespace Epr3.Models
{
    public class BasketProductModel
    {
        public int Id { get; set; }
        public double CurrentInventory { get; set; }
        public string Name { get; set; }
        public double QuantityBasket { get; set; }
        public BasketProductModel(int id, double currentInventory, string name, double quantityBasket)
        {
            Id = id;
            CurrentInventory = currentInventory;
            Name = name;
            QuantityBasket = quantityBasket;
        }
    }
}