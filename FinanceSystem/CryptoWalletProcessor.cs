namespace FinanceSystem
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing crypto transaction: ${transaction.Amount} for {transaction.Category}");
        }
    }
}