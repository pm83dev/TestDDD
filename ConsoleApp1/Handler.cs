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
                // Recupera gli eventi esistenti dal event store
        var events = await _eventStore.GetEventsAsync(orderId);

        // Crea un'istanza di AggregateOrder e applica gli eventi esistenti
        var order = new AggregateOrder();
        foreach (var @event in events)
        {
            order.Apply(@event);
        }

        // Applica l'aggiornamento all'istanza esistente
        order.UpdateOrder(orderId, customerId, orderQty);

        // Salva i nuovi eventi nel event store
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

            foreach (var @event in events)
            {
                order.Apply(@event);
            }

            return order;
        }
       }
}