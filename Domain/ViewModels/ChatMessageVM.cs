using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class ChatMessageVM
    {

        public string MessageBody;
        public string MessageDate;
        public string MessageTime;
        public string CssSelector1, CssSelector2;
        public string Mood;

        public ChatMessageVM(string Body, string Date, string Time, bool IsFromAgent, string Mo)
        {
            MessageBody = Body;
            MessageDate = Date;
            MessageTime = Time;
            CssSelector1 = (IsFromAgent) ? "outgoing_msg" : "incoming_msg";
            CssSelector2 = (CssSelector1 == "incoming_msg") ? "received_msg" : "sent_msg";
            Mood = Mo;
        }
    }
}