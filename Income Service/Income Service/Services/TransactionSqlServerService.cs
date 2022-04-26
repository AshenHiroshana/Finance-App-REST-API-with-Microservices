using Finance_App.Entity;
using Income_Service.DataAccess;

namespace Income_Service.Services
{
    public class TransactionSqlServerService : ITransactionRepository
    {
        private readonly IncomeDbContext _context = new IncomeDbContext();

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Find(id);
        }
    }
}
