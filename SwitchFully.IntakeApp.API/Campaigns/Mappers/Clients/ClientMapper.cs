using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.Domain.Campaigns;

namespace SwitchFully.IntakeApp.API.Campaigns.Mappers.Clients
{
    public class ClientMapper : IClientMapper
    {
        public Client ClientDTOCreateToClient(ClientDTO_Create clientDTO)
        {
            var client = Client.CreateNewClient(
                clientDTO.Name);
            return client;
        }

        public List<Client> ClientDTOListCreateToClientList(List<ClientDTO_Create> clients)
        {
            var clientList = new List<Client>();
            foreach (var client in clients)
            {
                clientList.Add(ClientDTOCreateToClient(client));
            }
            return clientList;
        }

        public List<ClientDTO_Return> ClientListToClientDTOReturnList(List<Client> clients)
        {
            var clientDTOReturnList = new List<ClientDTO_Return>();
            foreach (var client in clients)
            {
                clientDTOReturnList.Add(ClientToClientDTOReturn(client));
            }
            return clientDTOReturnList;
        }

        public  ClientDTO_Return ClientToClientDTOReturn(Client client)
        {
            return new ClientDTO_Return()
            {
                ClientId = client.ClientId,
                Name = client.Name
            };
        }
    }
}
