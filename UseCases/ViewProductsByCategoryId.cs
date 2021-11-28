using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class ViewProductsByCategoryId : IViewProductsByCategoryId
{
    private readonly IProductRepository productRepository;

    public ViewProductsByCategoryId(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public IEnumerable<Product> Execute(int categoryId)
    {
        return productRepository.GetProductsByCategoryId(categoryId);
    }
}
