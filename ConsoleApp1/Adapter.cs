using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static ConsoleApp1.Port;

namespace ConsoleApp1
{

    class Controller(IdirectSender idirectSender)
    {
        public async Task Create()
        {
            // Simula un'operazione asincrona
            await Task.Delay(1000);

            var entity = new Entity
            {
                Name = new ValueObject.ProdName("Nome1"), // Assegna ProdName alla proprietà Name
                Code = new ValueObject.Code("Codice1")   // Assegna Code alla proprietà Code
            };

            Console.WriteLine("creazione entity");
            await idirectSender.Send(entity);
        }
    }
}
