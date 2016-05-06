using System;
using NUnit.Framework;
using EventBus.Demo;

namespace EventBus
{
    
    public class UnitTest1
    {
        [TestCase]
        public void TestMethod1()
        {

            EventBus.Default.Init();

            EventBus.Default.Publish( new CreateOrderForCarSourceEvent() { CarSourceID =1, CarSourceName ="car1" , CarSourcePrice = 999 } );






        }
    }
}
