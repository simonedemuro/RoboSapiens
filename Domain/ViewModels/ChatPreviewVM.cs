using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class ChatPreviewVM
    {
        public string ChatTitle;
        public string PreviewMessage;
        public string LastMessageDate;

        public ChatPreviewVM(string chatTitle, string previewMessage, string lastMessageDate)
        {
            ChatTitle = chatTitle;
            PreviewMessage = previewMessage;
            LastMessageDate = lastMessageDate;
        }
    }
}
