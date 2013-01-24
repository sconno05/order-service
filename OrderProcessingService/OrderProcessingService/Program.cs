using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingService
{
    class Program
    {
        private const string ORDER_QUEUE_PATH = @".\private$\Orders";
        private static MessageQueue _orderQueue;

        static void Main(string[] args)
        {
            _orderQueue = new MessageQueue(ORDER_QUEUE_PATH, QueueAccessMode.Receive);
            _orderQueue.PeekCompleted += _orderQueue_PeekCompleted;
            _orderQueue.BeginPeek();
            Console.ReadLine();
        }

        static void _orderQueue_PeekCompleted(object sender, PeekCompletedEventArgs e)
        {
            var orderQueue = (MessageQueue)sender;

            var transaction = new MessageQueueTransaction();
            transaction.Begin();

            Order order;

            try
            {
                var receivedMessage = orderQueue.Receive(transaction);
                receivedMessage.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                order = Order.DeserializeXml(receivedMessage.Body.ToString());

                using (var db = new OrderContext())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                }

                transaction.Commit();
            }
            catch
            {
                // TODO: Log something
                transaction.Abort();
            }
            finally
            {
                orderQueue.BeginPeek();
            }

        }
    }
}
