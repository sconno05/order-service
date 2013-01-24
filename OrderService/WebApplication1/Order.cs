using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OrderService
{
    [RestService("orders")]
    public class Order
    {
        public string OrderName { get; set; }
        public decimal OrderPrice { get; set; }

        public string ToXml()
        {
            XDocument xml = new XDocument();
            XElement order = new XElement("Order");
            xml.Add(order);

            order.Add(new XElement("OrderName", this.OrderName));
            order.Add(new XElement("OrderPrice", this.OrderPrice.ToString()));

            return xml.ToString();
        }
    }
}