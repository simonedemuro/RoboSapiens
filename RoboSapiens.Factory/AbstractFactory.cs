using RoboSapiens.Repository;
using RoboSapiens.Repository.Mock;
using System;

namespace RoboSapiens.Factory
{
    public static class AbstractFactory
    {
        
        public static IConversationsRepository GetRepository()
        {
            // Todo: Read from Configuration
            bool _runWithoutDatabase = false;
            if (_runWithoutDatabase)
            {
                return new ConversationsRepositoryMock();
            }
            return new ConversationsRepository(new EF.Models.SupportSapiensContext());
        }
    }
}
