using System;

namespace ConsoleApp1
{
    public class Receiver
    {
        public interface IDomainReceiver
        {
            void HandleProduct(Entity entity);
        }

        public class DomainReceiver:IDomainReceiver
        {
            public void HandleProduct(Entity entity)
            {
                Console.WriteLine("chiamata handle o publish");
            }
        }
    }
}
