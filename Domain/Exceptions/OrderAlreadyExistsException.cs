namespace Domain.Exceptions
{
    public class OrderAlreadyExistsException : Exception
    {
        public OrderAlreadyExistsException() : base("Заказ уже существует!")
        {
        }
    }
}
