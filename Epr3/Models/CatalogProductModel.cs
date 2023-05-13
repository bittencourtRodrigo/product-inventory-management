using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Epr3.Models
{
    public class CatalogProductModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Uid { get; set; }
        public long Barcode { get; set; }
        public double CurrentInventory { get; set; }
        public string StoreLocation { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public string Observation { get; set; }

        public CatalogProductModel() { }

        public CatalogProductModel(string uid,long barcode, double currentInventory
            , string name, double costPrice, double salePrice, string observation = "")
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