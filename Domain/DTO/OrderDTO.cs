using Domain.Entities;

namespace Domain.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public statusOrder status { get; set; }

        public List<Lines> lines { get; set; }
    }

    public class Lines
    {
        public Guid Id { get; set; }
        public int quantity { get; set; }
    }
}
