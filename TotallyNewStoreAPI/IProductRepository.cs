using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyNewStoreAPI
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);

        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}
