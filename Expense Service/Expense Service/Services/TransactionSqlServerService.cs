using Expense_Service.Models;
using Expense_Service.DataAccess;

namespace Expense_Service.Services
{
    public class TransactionSqlServerService : ITransactionRepository
    {
        private readonly ExpenseDbContext _context = new ExpenseDbContext();
        private readonly ExpenseDbContext _context1 = new ExpenseDbContext();
        private readonly ExpenseDbContext _context2 = new ExpenseDbContext();

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
