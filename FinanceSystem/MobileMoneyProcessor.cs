namespace FinanceSystem
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing mobile money: ${transaction.Amount} for {transaction.Category}");
        }
    }
}