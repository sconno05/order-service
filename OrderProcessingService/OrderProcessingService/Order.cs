using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderProcessingService
{
    class Order
    {
        [Key]
        public int Id { get; private set; }
        public string OrderName { get; private set; }
        public decimal OrderPrice { get; private set; }

        public Order(string orderName, decimal orderPrice)
        {
            this.OrderName = orderName;
            this.OrderPrice = orderPrice;
        }

        public static Order DeserializeXml(string orderXml)
        {
            var doc = XDocument.Parse(orderXml);
            var order = doc.Element("Order");
            string orderName = order.Element("OrderName").Value;
            decimal orderPrice = Convert.ToDecimal(order.Element("OrderPrice").Value);

            return new Order(orderName, orderPrice);
        }
    }
}
