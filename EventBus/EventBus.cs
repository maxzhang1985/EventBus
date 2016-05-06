using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public void Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
             Type[] handlerTypes = _eventHandlerMapper.GetEventHandler(typeof(TEvent));

            foreach(var handlerType in handlerTypes)
            {

                try
                {
                    var invokeMethodInfo = handlerType.GetMethod("Handle", new Type[] { typeof(TEvent) });
                    if (invokeMethodInfo != null)
                    {
                        var eventHandler = Activator.CreateInstance(handlerType);

                        var asyncHandlerAttributeList = invokeMethodInfo.GetCustomAttributes(typeof(AsyncHandlerAttribute), false);
                        if (asyncHandlerAttributeList.Length > 0)
                        {
                            Task.Factory.StartNew((state) => invokeMethodInfo.Invoke(eventHandler, new object[] { state }),  
                                state: evt ,  creationOptions: TaskCreationOptions.LongRunning);
                        }
                        else
                        {
                            invokeMethodInfo.Invoke(eventHandler, new object[] { evt });
                        }
                    }
                }
                catch (Exception) {   }
                finally { }
                
            }

        }
    }
}
