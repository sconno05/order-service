using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Web;
using System.Xml.Linq;

namespace OrderService
{
    public class OrderService : RestServiceBase<Order>
    {
        private const string ORDER_QUEUE_PATH = @".\private$\Orders";

        public override object OnGet(Order request)
        {
            throw new NotImplementedException();
        }

        public override object OnPost(Order request)
        {
            MessageQueue orderQueue = new MessageQueue(ORDER_QUEUE_PATH, QueueAccessMode.SendAndReceive);

            if (!MessageQueue.Exists(orderQueue.Path))
            {
                MessageQueue.Create(orderQueue.Path, transactional:true);
            }

            MessageQueueTransaction transaction = new MessageQueueTransaction();
            transaction.Begin();

            try
            {
                Message message = new Message(request.ToXml());
                message.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                orderQueue.Send(message, transaction);
                transaction.Commit();
            }
            catch (Exception e)
            {
                // TODO: Log this somewhere
                transaction.Abort();
                throw e; // ServiceStack will automatically interpret an exception as an HTTP error: https://github.com/ServiceStack/ServiceStack/wiki/Validation
            }
            finally
            {
                orderQueue.Close();
            }

            return "OK";
        }
    }
}