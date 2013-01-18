using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class OrderService : RestServiceBase<Order>
    {
        public override object OnGet(Order request)
        {
            throw new NotImplementedException();
        }

        public override object OnPost(Order request)
        {
            // TODO: This is where we queue up to MSMQ and return SUCCESS
            return "Not queued (yet)!";
        }
    }
}