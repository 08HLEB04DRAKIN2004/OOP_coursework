using OOP.Domain.Entity;
using OOP.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Service.Interfaces
{
	public interface IClientService
	{
		IBaseResponse<List<ClientViewModel>> GetAllClients();

		Task<IBaseResponse<ClientViewModel>> GetClientById(int clientId);

		Task<IBaseResponse<ClientViewModel>> CreateClient(ClientViewModel client);

		Task<IBaseResponse<bool>> DeleteClient(int clientId);

		Task<IBaseResponse<ClientViewModel>> UpdateClient(int clientId, ClientViewModel updatedClient);
	}



}
