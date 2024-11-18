using System;

namespace ConsoleApp1
{
    public interface IEvent { }

    public class OrderCreated : IEvent
    {
        public Guid OrderId { get; private set; }
        public string CustomerId { get; private set; }
        public int OrderQty { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public OrderCreated(Guid orderId, string customerId, int orderQty, DateTime createdAt)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderQty = orderQty;
            CreatedAt = createdAt;
        }
    }

    public class OrderUpdated : IEvent
    {
        public Guid OrderId { get; private set; }
        public string CustomerId { get; private set; }
        public int OrderQty { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public OrderUpdated(Guid orderId, string customerId, int orderQty, DateTime updatedAt)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderQty = orderQty;
            UpdatedAt = updatedAt;
        }
    }

    public class OrderShipped : IEvent
    {
        public Guid OrderId { get; private set; }
        public DateTime ShippedAt { get; private set; }

        public OrderShipped(Guid orderId, DateTime shippedAt)
        {
            OrderId = orderId;
            ShippedAt = shippedAt;
        }
    }
}
