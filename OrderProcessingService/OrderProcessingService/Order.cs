using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderProcessingService
{
    public class Order
    {
        //TODO: Consider an ID

        public string OrderName { get; private set; }
        public decimal OrderPrice { get; private set; }

        public Order(string orderName, decimal orderPrice)
        {
            this.OrderName = orderName;
            this.OrderPrice = orderPrice;
        }

        public static Order DeserializeXml(string orderXml)
        {
            // TODO: Add some validation

            var doc = XDocument.Parse(orderXml);
            string orderName = doc.Element("OrderName").Value;
            decimal orderPrice = Convert.ToDecimal(doc.Element("OrderPrice").Value);

            return new Order(orderName, orderPrice);
        }
    }
}
