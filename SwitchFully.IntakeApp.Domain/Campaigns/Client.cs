using System;

namespace SwitchFully.IntakeApp.Domain.Campaigns
{
    public  class Client
    {
        public Guid ClientId { get; private set; }
        public string Name { get; private set; }

        private Client() { }

        private Client(string name)
        {
            ClientId = Guid.NewGuid();
            Name = name;
        }

        public static Client CreateNewClient(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            return new Client(name);
        }
    }
}