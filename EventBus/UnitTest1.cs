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

            CarSourceOrder orderBuss = new CarSourceOrder();

            var neworder = orderBuss.CreateOrder(new DearCarInfo() { ID =1, Name="car1", Price = 10000 }, true);


            neworder.CommitOrder();

        }
    }
}
