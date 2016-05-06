using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Demo
{
    public class CreateOrderExpressEventHandler : IEventHandler<OrderCreateExpressEvent>
    {
        public void Handle(OrderCreateExpressEvent e)
        {
            Console.WriteLine("已建立order:"+e.OrderID+"的物流信息");
        }
    }
}
