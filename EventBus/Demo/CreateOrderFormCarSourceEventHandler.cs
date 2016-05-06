using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Demo
{
    public class CreateOrderFormCarSourceEventHandler : IEventHandler<CreateOrderForCarSourceEvent> 
    {

       
        public void Handle(CreateOrderForCarSourceEvent e)
        {
           
            Console.WriteLine(string.Format("create order form car source, id:{0} , name:{1} , price:{2}" , e.CarSourceID , e.CarSourceName , e.CarSourcePrice));


            e.OrderID = 5;
        }




    }
}
