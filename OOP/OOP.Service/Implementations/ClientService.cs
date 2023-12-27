using Microsoft.EntityFrameworkCore;
using OOP.DAL.Interface;
using OOP.DAL.Repositories;
using OOP.Domain.Entity;
using OOP.Domain.Enum;
using OOP.Domain.Response;
using OOP.Service.Interfaces;

namespace OOP.Service.Implementations
{
	public class ClientService : IClientService
	{
		private readonly IBaseRepository<Client> _clientRepository;

		public ClientService(IBaseRepository<Client> clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public IBaseResponse<List<ClientViewModel>> GetAllClients()
		{
			try
			{
				var clients = _clientRepository.GetAll();
				var clientViewModels = clients.Select(c => new ClientViewModel
				{
					ClientId = c.Client_id,
					Name = c.name,
					ContactInformation = c.contact_information,
					Contract = c.contract
				}).ToList();

				return new BaseResponse<List<ClientViewModel>>
				{
					Description = "Clients retrieved successfully",
					StatusCode = StatusCode.Success,
					Data = clientViewModels
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<ClientViewModel>>
				{
					Description = $"Failed to retrieve clients. {ex.Message}",
					StatusCode = StatusCode.Error,
					Data = null
				};
			}
		}

		public async Task<IBaseResponse<ClientViewModel>> GetClientById(int clientId)
		{
			try
			{
				var client = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Client_id == clientId);

				if (client != null)
				{
					var clientViewModel = new ClientViewModel
					{
						ClientId = client.Client_id,
						Name = client.name,
						ContactInformation = client.contact_information,
						Contract = client.contract
					};

					return new BaseResponse<ClientViewModel>
					{
						Description = "Client retrieved successfully",
						StatusCode = StatusCode.Success,
						Data = clientViewModel
					};
				}
				else
				{
					return new BaseResponse<ClientViewModel>
					{
						Description = "Client not found",
						StatusCode = StatusCode.NotFound,
						Data = null
					};
				}
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClientViewModel>
				{
					Description = $"Failed to retrieve client. {ex.Message}",
					StatusCode = StatusCode.Error,
					Data = null
				};
			}
		}

		public async Task<IBaseResponse<ClientViewModel>> CreateClient(ClientViewModel client)
		{
			try
			{
				var newClient = new Client
				{
					name = client.Name,
					contact_information = client.ContactInformation,
					contract = client.Contract
				};

				// Предположим, что _clientRepository.Create асинхронный и возвращает Task
				await _clientRepository.Create(newClient);

				var createdClientViewModel = new ClientViewModel
				{
					ClientId = newClient.Client_id,
					Name = newClient.name,
					ContactInformation = newClient.contact_information,
					Contract = newClient.contract
				};

				return new BaseResponse<ClientViewModel>
				{
					Description = "Client created successfully",
					StatusCode = StatusCode.Success,
					Data = createdClientViewModel
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClientViewModel>()
				{
					Description = $"[Create] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}


		public async Task<IBaseResponse<bool>> DeleteClient(int clientId)
		{
			try
			{
				var existingClient = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Client_id == clientId);

				if (existingClient != null)
				{
					await _clientRepository.Delete(existingClient);

					return new BaseResponse<bool>
					{
						Description = "Client deleted successfully",
						StatusCode = StatusCode.Success,
						Data = true
					};
				}
				else
				{
					return new BaseResponse<bool>
					{
						Description = "Client not found",
						StatusCode = StatusCode.NotFound,
						Data = false
					};
				}
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>
				{
					Description = $"Failed to delete client. {ex.Message}",
					StatusCode = StatusCode.Error,
					Data = false
				};
			}
		}
		public async Task<IBaseResponse<ClientViewModel>> UpdateClient(int clientId, ClientViewModel updatedClient)
		{
			try
			{
				var existingClient = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Client_id == clientId);

				if (existingClient != null)
				{
					existingClient.name = updatedClient.Name;
					existingClient.contact_information = updatedClient.ContactInformation;
					existingClient.contract = updatedClient.Contract;

					var updatedClientEntity = await _clientRepository.Update(existingClient);

					var updatedClientViewModel = new ClientViewModel
					{
						ClientId = updatedClientEntity.Client_id,
						Name = updatedClientEntity.name,
						ContactInformation = updatedClientEntity.contact_information,
						Contract = updatedClientEntity.contract
					};

					return new BaseResponse<ClientViewModel>
					{
						Description = "Client updated successfully",
						StatusCode = StatusCode.Success,
						Data = updatedClientViewModel
					};
				}
				else
				{
					return new BaseResponse<ClientViewModel>
					{
						Description = "Client not found",
						StatusCode = StatusCode.NotFound,
						Data = null
					};
				}
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClientViewModel>
				{
					Description = $"Failed to update client. {ex.Message}",
					StatusCode = StatusCode.Error,
					Data = null
				};
			}
		}
	}
}