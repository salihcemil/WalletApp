
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    public class ConnectorHub : Hub
    {
        public ConnectorHub()
        {
        }
        public void DetermineLength(string message)
        {
            Console.WriteLine("Broadcasting message: " + message);
            string newMessage = string.Format(@"{0} has a length of: {1}", message, message.Length);
            Clients.Others.newMessageReceived(message);
            OnConnected();
        }

        public void NewMessage(string Message)
        {
            Clients.All.newMessageReceived(Message);
        }

        public override Task OnConnected()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }
    }
}
