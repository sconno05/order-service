using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderService
{
    [RestService("orders")]
    [Serializable]
    public class Order
    {
        //TODO: Consider an ID

        public string OrderName { get; set; }
        public decimal OrderPrice { get; set; }
    }
}