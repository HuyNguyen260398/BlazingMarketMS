using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
{
    private readonly ITransactionRepository transactionRepository;

    public GetTodayTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        this.transactionRepository = transactionRepository;
    }

    public IEnumerable<Transaction> Execute(string cashierName)
    {
        return transactionRepository.GetByDay(cashierName, DateTime.Now);
    }
}
