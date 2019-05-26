using RoboSapiens.EF.Models;
using System;

namespace RoboSapiens.Core
{
    public class WebAppMessage : IComunicationChannel
    {
        // TODO: Implement the following method with Signal R or WebSocket 
        public void MessageReceived(Message msg)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
