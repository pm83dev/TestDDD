using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace ConsoleApp1
{
    public class CommandHandler
    {
       private readonly IEventStore _eventStore;

        public CommandHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

       public async Task HandleCreateOrderAsync(Guid orderId, string customerId, int orderQty)
       {
            var order = AggregateOrder.CreateOrder(orderId, customerId, orderQty);
            await _eventStore.SaveEventsAsync(orderId, order.Events);    
       }

       public async Task HandleUpdateOrderAsync(Guid orderId, string customerId, int orderQty)
       {
            var order = AggregateOrder.UpdateOrder(orderId, customerId, orderQty);
            await _eventStore.SaveEventsAsync(orderId, order.Events);
       }
    }

    public class OrderQueryHandler
       {
        private readonly IEventStore _eventStore;

        public OrderQueryHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<AggregateOrder> GetOrderAsync(Guid orderId)
        {
            var events = await _eventStore.GetEventsAsync(orderId);
            var order = new AggregateOrder();

            Console.WriteLine("Order before applying events:");
            Console.WriteLine(order);

            foreach (var @event in events)
            {
                order.Apply(@event);
            }

            // Stampa tutti gli eventi presenti nella lista
            Console.WriteLine("Events in order:");
            foreach (var evt in order.Events)
            {
                string json = JsonSerializer.Serialize(evt, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
            }

            return order;
        }

       }
}