using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderProcessingService
{
    class OrderDto
    {
        public string OrderName { get; private set; }
        public decimal OrderPrice { get; private set; }

        public OrderDto(string orderName, decimal orderPrice)
        {
            this.OrderName = orderName;
            this.OrderPrice = orderPrice;
        }

        public static OrderDto DeserializeXml(string orderXml)
        {
            // TODO: Add some validation

            var doc = XDocument.Parse(orderXml);
            var order = doc.Element("Order");
            string orderName = order.Element("OrderName").Value;
            decimal orderPrice = Convert.ToDecimal(order.Element("OrderPrice").Value);

            return new OrderDto(orderName, orderPrice);
        }
    }
}
