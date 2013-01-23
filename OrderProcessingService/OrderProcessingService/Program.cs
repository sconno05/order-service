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
            _orderQueue.ReceiveCompleted += _orderQueue_ReceiveCompleted;
            _orderQueue.BeginReceive();

            // TODO: Figure out what to do on close
        }

        static void _orderQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue orderQueue = (MessageQueue)sender;

            Order order;

            try
            {
                Message receivedMessage = orderQueue.EndReceive(e.AsyncResult);
                order = Order.DeserializeXml(receivedMessage.Body.ToString());
            }
            catch (Exception exception)
            {
                // TODO: Log this somewhere.
                Console.WriteLine(exception);
            }

            orderQueue.Refresh();
            orderQueue.BeginPeek();
        }
    }
}
