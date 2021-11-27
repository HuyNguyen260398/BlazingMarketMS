using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases;

public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IProductRepository productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public Product Execute(int productId)
    {
        return productRepository.GetProductById(productId);
    }
}
