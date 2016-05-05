using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus
{
    public class EventHandlerMapper
    {
        //key is event type , value are handler type for the list ;
        //one event type can map to muti hanlder types
        static private Dictionary<Type, List<Type>> mapEventToHandlerDic = new Dictionary<Type, List<Type>>();


        public EventHandlerMapper(IEnumerable<Type> eventHandlerTypes)
        {
            foreach (Type eventHandlerType in eventHandlerTypes)
            {
                MapEventToHander(eventHandlerType);
            }

        }



        private void MapEventToHander(Type handlerType)
        {
            //all IEventHandler interface of the handler type
            var handlerInterfaces = from i in handlerType.GetInterfaces()
                        where i.Name == typeof(IEventHandler<>).Name
                        select i;

            foreach(Type eventInterface in handlerInterfaces)
            {
                //IEvent type , such as 'IEventHandler<IEvent>'
                Type eventType = eventInterface.GetGenericArguments()[0];
                if(mapEventToHandlerDic.Keys.Contains(eventType))
                {
                    var handlerTypes = mapEventToHandlerDic[eventType];
                    handlerTypes.Add(handlerType);
                    mapEventToHandlerDic[eventType] = handlerTypes ;
                }
                else
                {
                    List<Type> handlerTypes = new List<Type>();
                    handlerTypes.Add(handlerType);
                    mapEventToHandlerDic[eventType] = handlerTypes;
                }

            }


        }



        public Type[] GetEventHandler(Type eventType)
        {
            return mapEventToHandlerDic[eventType].ToArray();
        }



    }
}
