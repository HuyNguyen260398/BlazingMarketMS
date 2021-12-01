using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugin.DataStore.InMemory;

public class TransactionInMemoryRepository : ITransactionRepository
{
    private List<Transaction> transactions;

    public TransactionInMemoryRepository()
    {
        transactions = new();
    }

    public IEnumerable<Transaction> Get(string cashierName)
    {
        if (string.IsNullOrEmpty(cashierName))
            return transactions;
        else
            return transactions.Where(t => t.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
    {
        if (string.IsNullOrEmpty(cashierName))
            return transactions.Where(t => t.TimeStamp.Date == date.Date);
        else
            return transactions.Where(t => 
            t.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase) &&
            t.TimeStamp.Date == date.Date);
    }

    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrEmpty(cashierName))
            return transactions.Where(t => t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date);
        else
            return transactions.Where(t =>
            t.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase) &&
            t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date);
    }

    public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        int transactionId = 0;
        if (transactions != null && transactions.Count > 0)
        {
            int maxId = transactions.Max(x => x.TransactionId);
            transactionId = maxId + 1;
        }

        transactions.Add(new Transaction
        {
            TransactionId = transactionId,
            ProductId = productId,
            ProductName = productName,
            TimeStamp = DateTime.Now,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            CashierName = cashierName,
        });
    }
}
