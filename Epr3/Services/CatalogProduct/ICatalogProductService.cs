using Epr3.Models;
using Epr3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epr3.Services.CatalogProduct
{
    public interface ICatalogProductService
    {
        Task<List<CatalogProductModel>> ProductGetAll();
    }
}
