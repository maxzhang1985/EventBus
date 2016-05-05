using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Demo
{
    public class CreateOrderForCarSourceEvent : IEvent
    {


        public int CarSourceID { set; get; }
        public string CarSourceName { set; get; }
        public int CarSourcePrice { set; get; }

    }
}
