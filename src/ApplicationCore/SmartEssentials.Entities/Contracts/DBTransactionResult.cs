namespace SmartEssentials.Entities.Contracts
{
    public class DBTransactionResult<T>
    {
        public T Obj { get; set; }
        public bool IsTransactionSuccess { get; set; }
    }
}
