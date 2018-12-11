using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.Domain.Campaigns;
using System.Collections.Generic;

namespace SwitchFully.IntakeApp.API.Campaigns.Mappers.Clients
{
	public interface IClientMapper
	{
		List<Client> ClientDTOListCreateToClientList(List<ClientDTO_Create> clients);
		List<ClientDTO_Return> ClientListToClientDTOReturnList(List<Client> clients);
		ClientDTO_Return ClientToClientDTOReturn(Client client);
	}
}
