using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TotallyNewStoreAPI
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = PracticeCommerce; Integrated Security = True;";

        private static string getProductByIdSQLquery = @"SELECT * FROM Products Where [Id] = @Skittles";
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Product>("SELECT * from Products");
            return response;
     
        }

        public async Task<Product> AddProductAsync(Product product)
        {
           var _connection = new SqlConnection(_connectionString); 
           var response = await _connection.ExecuteAsync(@"Insert INTO Products (Price, Name, Description) VALUES (@Price, @Name, @Description)", product);
 
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var connection = new SqlConnection(_connectionString);
            var response = await connection.QueryAsync<Product>(getProductByIdSQLquery, new { Skittles = id });
            return response.FirstOrDefault();
        }
    }
}
