using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.SignalR {
    public class MyChat : Hub {

        public void Send(string message) {

            //Clients.addMessage(message);

        }

    }
}