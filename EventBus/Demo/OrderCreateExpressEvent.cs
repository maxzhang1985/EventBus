using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Demo
{
    public class OrderCreateExpressEvent : IEvent
    {
        public int OrderID { set; get; }



    }
}
