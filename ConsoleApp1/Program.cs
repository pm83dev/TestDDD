using System.Reflection.Metadata.Ecma335;
using ConsoleApp1;
using static ConsoleApp1.Port;

internal class Program
{
    static async Task Main(string[] args)
        {
          IdirectSender sender = new Sender();
          Controller adapter = new Controller(sender);
          await adapter.Create();  
        }
}