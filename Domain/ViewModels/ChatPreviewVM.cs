using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class ChatPreviewVM
    {
        public int ChatID;
        public string Username;
        public string PreviewMessage;
        public string LastMessageDate;

        public ChatPreviewVM(int ID, string chatTitle, string preview, string lastMessageDate)
        {
            Username = chatTitle;
            PreviewMessage = preview;
            LastMessageDate = lastMessageDate;
        }
    }
}