using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugin.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            // Init products list with default values
            products = new()
            {
                new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 9.99 },
                new Product { ProductId = 2, CategoryId = 2, Name = "Apple Pie", Quantity = 50, Price = 19.99 },
                new Product { ProductId = 3, CategoryId = 3, Name = "Fried Chicken", Quantity = 50, Price = 49.99 },
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
