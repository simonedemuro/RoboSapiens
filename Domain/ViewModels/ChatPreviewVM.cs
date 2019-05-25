using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class ChatPreviewVM
    {
        public long ChatID;
        public string Username;
        public string PreviewMessage;
        public string LastMessageDate;

        public ChatPreviewVM(long ID, string chatTitle, string preview, string lastMessageDate)
        {
            ChatID = ID;
            Username = chatTitle;
            PreviewMessage = preview;
            LastMessageDate = lastMessageDate;
        }
    }
}