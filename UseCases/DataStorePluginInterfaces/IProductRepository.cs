using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetProducts();
    }
}
