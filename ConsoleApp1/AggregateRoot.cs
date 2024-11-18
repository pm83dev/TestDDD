using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp1
{
    public class AggregateOrder
    {   
        public Guid OrderId{get;private set;}
        public string ?CustomerId{get;private set;}
        public int OrderQty {get; private set;}
        public bool Created {get;private set;}
        public bool Shipped {get; private set;}

        public List<IEvent> Events {get;} = new List<IEvent>();

        public static AggregateOrder CreateOrder(Guid orderId, string customerId,int orderQty ,bool created=false)
        {
            var order = new AggregateOrder();
            order.Apply(new OrderCreated(orderId, customerId, orderQty, DateTime.Now));
            return order;
        }

        public static AggregateOrder UpdateOrder(Guid orderId, string customerId, int orderQty)
        {
            var order = new AggregateOrder();
            order.Apply(new OrderUpdated(orderId, customerId, orderQty, DateTime.Now));
            return order;   
        }

        public override string ToString()
        {
            var eventsAsString = string.Join(Environment.NewLine, Events.Select(e => 
                JsonSerializer.Serialize(e, new JsonSerializerOptions { WriteIndented = true })));

            return $"Order: {OrderId} - Created: {Created} - Events:\n{eventsAsString}";
        }


        public void Apply(IEvent @event)
        {
            Events.Add(@event);
            
            if(@event is OrderCreated oc)
            {
                OrderId = oc.OrderId;
                CustomerId = oc.CustomerId;
                Created = true;    
            }

            else if (@event is OrderUpdated ou)
            {
                OrderId = ou.OrderId;
                CustomerId = ou.CustomerId;
                OrderQty = ou.OrderQty;
            }

            else if (@event is OrderShipped os)
            {
                OrderId = os.OrderId;
                Shipped = true;
            }
        }
    }
}