namespace FinanceSystem
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            // Create account
            var account = new SavingsAccount("123456789", 1000m);
            
            // Create transactions
            var transaction1 = new Transaction(1, DateTime.Now, 50m, "Groceries");
            var transaction2 = new Transaction(2, DateTime.Now, 100m, "Utilities");
            var transaction3 = new Transaction(3, DateTime.Now, 75m, "Entertainment");
            
            // Process transactions
            new MobileMoneyProcessor().Process(transaction1);
            new BankTransferProcessor().Process(transaction2);
            new CryptoWalletProcessor().Process(transaction3);
            
            // Apply to account
            account.ApplyTransaction(transaction1);
            account.ApplyTransaction(transaction2);
            account.ApplyTransaction(transaction3);
            
            // Store transactions
            _transactions.Add(transaction1);
            _transactions.Add(transaction2);
            _transactions.Add(transaction3);
        }
    }
}