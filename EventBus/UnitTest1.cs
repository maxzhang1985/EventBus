using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventBus
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            AssemblyLoader.ResolveAssembly(AppDomain.CurrentDomain.BaseDirectory);
            var eventHandlerList = AssemblyLoader.TypesOf(typeof(IEventHandler<>));

            EventHandlerMapper mapper = new EventHandlerMapper(eventHandlerList);

        }
    }
}
