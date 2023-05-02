namespace Domain.Entities
{
    public class Order
    {
        public Guid id { get; set; }

        public statusOrder status { get; set; }

        public ICollection<OrderProduct> orderProducts { get; set; }

        public DateTime Created { get; set; }
    }

    public enum statusOrder
    {
        New,
        awaitingPayment,
        paid,
        handedForDelivery,
        delivered,
        completed
    }
}
