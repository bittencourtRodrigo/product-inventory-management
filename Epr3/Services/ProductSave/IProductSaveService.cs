using Epr3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epr3.Services.ProductSave
{
    public interface IProductSaveService
    {
        Task ProductSaveAsync(CatalogProductModel product);
    }
}
