namespace FinanceSystem
{
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}