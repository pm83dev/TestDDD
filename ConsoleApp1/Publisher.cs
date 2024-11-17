using System;

namespace ConsoleApp1
{
    public class Publisher
    {
        interface IPublish
        {
            void PublishToExt();
        }

        public class Publish:IPublish
        {
            public void PublishToExt()
            {
                Console.WriteLine("Publish to external");
            }
        }
    }
}
