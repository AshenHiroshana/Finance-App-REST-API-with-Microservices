using Income_Service.Models;
using Income_Service.DataAccess;

namespace Income_Service.Services
{
    public class TransactionSqlServerService : ITransactionRepository
    {
        private readonly IncomeDbContext _context = new IncomeDbContext();
        private readonly IncomeDbContext _context1 = new IncomeDbContext();
        private readonly IncomeDbContext _context2 = new IncomeDbContext();

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Find(id);
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;

        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            _context1.Transactions.Update(transaction);
            _context1.SaveChanges();
            return transaction;

        }

        public void DeleteTransaction(Transaction transaction)
        {
            _context1.Remove(transaction);
            _context1.SaveChanges();
        }
    }
}
