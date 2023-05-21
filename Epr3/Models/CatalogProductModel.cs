using Newtonsoft.Json;
using SQLite;

namespace Epr3.Models
{
    public class CatalogProductModel
    {
        [JsonProperty(PropertyName = "id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [JsonProperty(PropertyName = "uid")]
        public string? Uid { get; set; }
        
        [JsonProperty(PropertyName = "barcode")]
        public long Barcode { get; set; }
        
        [JsonProperty(PropertyName = "currentInventory")]
        public double CurrentInventory { get; set; }
        
        [JsonProperty(PropertyName = "storeLocation")]
        public string? StoreLocation { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        
        [JsonProperty(PropertyName = "costPrice")]
        public double CostPrice { get; set; }
        
        [JsonProperty(PropertyName = "salePrice")]
        public double SalePrice { get; set; }
        
        [JsonProperty(PropertyName = "observation")]
        public string? Observation { get; set; }

        public CatalogProductModel() { }

        public CatalogProductModel(string uid,long barcode, double currentInventory
            , string name, double costPrice, double salePrice, string observation = null)
        {
            Uid = uid;
            Barcode = barcode;
            CurrentInventory = currentInventory;
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Observation = observation;
        }
    }
}