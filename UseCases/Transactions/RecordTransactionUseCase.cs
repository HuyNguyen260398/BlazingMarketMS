using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.Transactions;

public class RecordTransactionUseCase : IRecordTransactionUseCase
{
    private readonly ITransactionRepository transactionRepository;
    private readonly IGetProductByIdUseCase getProductByIdUseCase;

    public RecordTransactionUseCase(
        ITransactionRepository transactionRepository,
        IGetProductByIdUseCase getProductByIdUseCase)
    {
        this.transactionRepository = transactionRepository;
        this.getProductByIdUseCase = getProductByIdUseCase;
    }

    public void Execute(string cashierName, int productId, string productName, int qty)
    {
        var product = getProductByIdUseCase.Execute(productId);
        transactionRepository.Save(cashierName, productId, productName, product.Price.Value, product.Quantity.Value, qty);
    }
}
