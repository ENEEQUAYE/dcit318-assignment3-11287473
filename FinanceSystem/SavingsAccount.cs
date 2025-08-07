namespace FinanceSystem
{
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance) 
            : base(accountNumber, initialBalance) { }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                base.ApplyTransaction(transaction);
                Console.WriteLine($"Transaction applied. New balance: {Balance}");
            }
        }
    }
}