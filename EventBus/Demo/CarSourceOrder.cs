using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Demo
{
    public class CarSourceOrder : AggregateRoot<int> 
    {
        public bool UseExpress { set; get; }

        
         public CarSourceOrder Get(int id)
        {
            //,,,取业务实体

            return new CarSourceOrder() {  ID = id , UseExpress = true };
        }



        public CarSourceOrder CreateOrder(DearCarInfo orderinfo,bool useExpress)
        {
            this.UseExpress = useExpress;

            var evt1 = new CreateOrderForCarSourceEvent()
            {
                CarSourceID = orderinfo.ID,
                CarSourceName = orderinfo.Name, 
                CarSourcePrice = orderinfo.Price,
                CarSourceType = 1
            };


            Publish(evt1);


            if (useExpress)
            {
                Publish(new OrderCreateExpressEvent() { OrderID = evt1.OrderID });
            }

            return new CarSourceOrder() { ID = evt1.OrderID, UseExpress = this.UseExpress };

        }


        public void CommitOrder()
        {
            Console.WriteLine("Commit order by " + this.ID);
            if(UseExpress)
            {
                //event to update express
            }
            else
            {
                //event to update the order state is no pay
            }


        }




    }
}
