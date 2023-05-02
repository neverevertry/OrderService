namespace Domain.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int count { get; set; }
    }
}
