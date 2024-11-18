using System.Reflection.Metadata.Ecma335;
using ConsoleApp1;
using static ConsoleApp1.Port;

internal class Program
{
    static async Task Main(string[] args)
        {
          /*
          IdirectSender sender = new Sender();
          Controller adapter = new Controller(sender);
          await adapter.Create();
          */
          var eventStore = new InMemoryEventStore();

          var CommandHandler = new CommandHandler(eventStore);

          var queryHandler = new OrderQueryHandler(eventStore);

          //Create order
          var orderId = Guid.NewGuid();
          var customerId = "customerTest1";
          var orderQty = 15;
          await CommandHandler.HandleCreateOrderAsync(orderId, customerId, orderQty);
          
          //Update order
          var newOrdQty = 20;
          orderQty = newOrdQty;
          await CommandHandler.HandleUpdateOrderAsync(orderId, customerId,orderQty);

          // Recupera l'ordine e visualizza lo stato
          var order = await queryHandler.GetOrderAsync(orderId);
          Console.WriteLine($"Order: {orderId} - created: {order.Created}");
        }
}