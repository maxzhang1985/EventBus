using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public class AggregateRoot<TID> : IAggregateRoot<TID>
    {
        public TID ID {  set; get; }

        protected void Publish<TEvent>(TEvent Event) where TEvent : IEvent
        {
            EventBus.Default.Publish(Event);
        }


    }
}
