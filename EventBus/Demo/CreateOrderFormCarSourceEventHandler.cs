using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Demo
{
    public class CreateOrderFormCarSourceEventHandler : IEventHandler<CreateOrderForCarSourceEvent> , IEventHandler<TestEvent>
    {
        public void Handle(TestEvent e)
        {
            Console.WriteLine("test event");
        }

        public void Handle(CreateOrderForCarSourceEvent e)
        {
            Console.WriteLine(string.Format("create order form car source, id:{0} , name:{1} , price:{2}" , e.CarSourceID , e.CarSourceName , e.CarSourcePrice));
        }




    }
}
