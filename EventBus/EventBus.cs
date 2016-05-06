using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus
{
    public class EventBus : IEventBus
    {
        private static object lockobject = new object();
        private static EventBus _bus;
        EventHandlerMapper _eventHandlerMapper;

        public static IEventBus Default
        {
           get
            {
                lock(lockobject)
                {
                    if(_bus==null )
                    {
                        _bus = new EventBus();
                    }
                }
                return _bus;
            }
        }


        public void Init()
        {
            AssemblyLoader.ResolveAssembly(AppDomain.CurrentDomain.BaseDirectory);
            var eventHandlerList = AssemblyLoader.TypesOf(typeof(IEventHandler<>));
            _eventHandlerMapper = new EventHandlerMapper(eventHandlerList);
        }



        public bool Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
             Type[] handlerTypes = _eventHandlerMapper.GetEventHandler(typeof(TEvent));

            foreach(var handlerType in handlerTypes)
            {




            }

            return true;
        }
    }
}
