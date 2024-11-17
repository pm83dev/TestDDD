using System;
using System.Dynamic;
using static ConsoleApp1.Publisher;

namespace ConsoleApp1
{
    public class Port
    {
        public interface IdirectSender
        {
            Task Send (Entity entity);
        }
        public class Sender:IdirectSender
        {
            public async Task Send(Entity entity)
            {
                Console.WriteLine("chiamata port");
                await Task.Delay (1000);
                Console.WriteLine($"Entity sent: {entity.Name}  {entity.Code}");
                await Task.Delay (1000);
                            
            }
        }
    }
}
