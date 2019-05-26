using RoboSapiens.EF.Models;

namespace RoboSapiens.Core
{
    public interface IComunicationChannel
    {
        void MessageReceived(Message msg);
        void SendMessage(Message msg);
    }
}