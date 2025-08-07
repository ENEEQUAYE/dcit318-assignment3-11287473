namespace FinanceSystem
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing bank transfer: ${transaction.Amount} for {transaction.Category}");
        }
    }
}