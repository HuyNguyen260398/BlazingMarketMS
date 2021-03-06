using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IProductRepository
{
    void AddProduct(Product product);
    IEnumerable<Product> GetProducts();
    Product GetProductById(int productId);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
    IEnumerable<Product> GetProductsByCategoryId(int categoryId);
}
