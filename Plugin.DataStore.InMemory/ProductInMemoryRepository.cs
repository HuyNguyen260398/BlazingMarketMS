using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugin.DataStore.InMemory;

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

    public void AddProduct(Product product)
    {
        if (products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            return;

        if (products != null && products.Count > 0)
        {
            var maxId = products.Max(p => p.ProductId);
            product.ProductId = maxId + 1;
        }
        else
        {
            product.ProductId = 1;
        }
        products.Add(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return products;
    }

    public Product GetProductById(int productId)
    {
        return products.FirstOrDefault(p => p.ProductId == productId);
    }

    public void UpdateProduct(Product product)
    {
        var productToUpdate = GetProductById(product.ProductId);
        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.Price = product.Price;
        }
    }

    public void DeleteProduct(int productId)
    {
        var productToDelete = GetProductById(productId);
        if (productToDelete != null)
            products.Remove(productToDelete);
    }
}
