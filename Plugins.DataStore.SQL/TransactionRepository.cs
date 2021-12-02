﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class TransactionRepository : ITransactionRepository
{
    private readonly MarketContext db;

    public TransactionRepository(MarketContext db)
    {
        this.db = db;
    }

    public IEnumerable<Transaction> Get(string cashierName)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
            return db.Transactions.ToList();
        else
            return db.Transactions.Where(t => t.CashierName.ToLower().Equals(cashierName.ToLower()));
    }

    public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
    {
        return Get(cashierName).Where(t => t.TimeStamp.Date == date.Date);
    }

    public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        var transaction = new Transaction
        {
            ProductId = productId,
            ProductName = productName,
            TimeStamp = DateTime.Now,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty,
            CashierName = cashierName,
        };

        db.Transactions.Add(transaction);
        db.SaveChanges();
    }

    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
        return Get(cashierName).Where(t => t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
    }
}
