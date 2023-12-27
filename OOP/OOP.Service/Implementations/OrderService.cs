using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OOP.DAL.Interface;
using OOP.DAL.Repositories;
using OOP.Domain.Entity;
using OOP.Domain.Response;
using OOP.Domain.ViewModel.Orders;
using OOP.Domain.Enum;
using OOP.Service.Interfaces;

namespace OOP.Service.Implementations
{
    public class OrderService: IOrderService
    {
        private readonly IBaseRepository<Orders> _ordersRepository;

        public OrderService(IBaseRepository<Orders> clientRepository)
        {
            _ordersRepository = clientRepository;
        }

        public IBaseResponse<List<OrdersViewModel>> GetAllOrders()
        {
            try
            {
                var clients = _ordersRepository.GetAll();
                var clientViewModels = clients.Select(c => new OrdersViewModel
                {
                    Order_id = c.Order_id,
                    Description = c.description,
                    Date = c.date,
                    Amount = c.amount,
                    Client_id=c.Client.Client_id
                }).ToList();

                return new BaseResponse<List<OrdersViewModel>>
                {
                    Description = "Clients retrieved successfully",
                    StatusCode = StatusCode.Success,
                    Data = clientViewModels
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<OrdersViewModel>>
                {
                    Description = $"Failed to retrieve clients. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = null
                };
            }
        }

        public async Task<IBaseResponse<OrdersViewModel>> GetOrdersById(int clientId)
        {
            try
            {
                var client = await _ordersRepository.GetAll().FirstOrDefaultAsync(x => x.Order_id == clientId);

                if (client != null)
                {
                    var orderViewModel = new OrdersViewModel
                    {
                        Order_id = client.Order_id,
                        Description = client.description,
                        Date = client.date,
                        Amount = client.amount,
                        Client_id = client.Client.Client_id
                    };

                    return new BaseResponse<OrdersViewModel>
                    {
                        Description = "Client retrieved successfully",
                        StatusCode = StatusCode.Success,
                        Data = orderViewModel
                    };
                }
                else
                {
                    return new BaseResponse<OrdersViewModel>
                    {
                        Description = "Client not found",
                        StatusCode = StatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdersViewModel>
                {
                    Description = $"Failed to retrieve client. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = null
                };
            }
        }

        public async Task<IBaseResponse<OrdersViewModel>> CreateOrder(OrdersViewModel client)
        {
            try
            {
                var newClient = new Orders
                {
                    Order_id = client.Order_id,
                    description = client.Description,
                    date = client.Date,
                    amount = client.Amount,
                    Client=client.Client
                };

                // Предположим, что _clientRepository.Create асинхронный и возвращает Task
                await _ordersRepository.Create(newClient);

                var createdClientViewModel = new OrdersViewModel
                {
                   Order_id = newClient.Order_id,
                    Description = newClient.description,
                    Date = newClient.date,
                    Amount = newClient.amount,
                    Client = newClient.Client
                };

                return new BaseResponse<OrdersViewModel>
                {
                    Description = "Client created successfully",
                    StatusCode = StatusCode.Success,
                    Data = createdClientViewModel
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdersViewModel>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<bool>> DeleteOrder(int clientId)
        {
            try
            {
                var existingClient = await _ordersRepository.GetAll().FirstOrDefaultAsync(x => x.Order_id == clientId);

                if (existingClient != null)
                {
                    await _ordersRepository.Delete(existingClient);

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
        public async Task<IBaseResponse<OrdersViewModel>> UpdateOrder(int clientId, OrdersViewModel updatedClient)
        {
            try
            {
                var existingClient = await _ordersRepository.GetAll().FirstOrDefaultAsync(x => x.Order_id == clientId);

                if (existingClient != null)
                {
                    existingClient.date = updatedClient.Date;
                    existingClient.description = updatedClient.Description;
                    existingClient.amount= updatedClient.Amount;

                    var updatedClientEntity = await _ordersRepository.Update(existingClient);

                    var updatedClientViewModel = new OrdersViewModel
                    {
                        Order_id= updatedClientEntity.Order_id,
                        Description = updatedClientEntity.description,
                        Date= updatedClientEntity.date,
                        Amount = updatedClientEntity.amount,
                        Client_id = updatedClientEntity.Client.Client_id
                    };

                    return new BaseResponse<OrdersViewModel>
                    {
                        Description = "Client updated successfully",
                        StatusCode = StatusCode.Success,
                        Data = updatedClientViewModel
                    };
                }
                else
                {
                    return new BaseResponse<OrdersViewModel>
                    {
                        Description = "Client not found",
                        StatusCode = StatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdersViewModel>
                {
                    Description = $"Failed to update client. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = null
                };
            }
        }
    }
}

