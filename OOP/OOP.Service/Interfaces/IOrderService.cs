using OOP.Domain.Response;
using OOP.Domain.ViewModel.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOP.Service.Interfaces
{
    public interface IOrderService
    {
        IBaseResponse<List<OrdersViewModel>> GetAllOrders();

        Task<IBaseResponse<OrdersViewModel>> GetOrdersById(int clientId);

        Task<IBaseResponse<OrdersViewModel>> CreateOrder(OrdersViewModel client);

        Task<IBaseResponse<bool>> DeleteOrder(int clientId);

        Task<IBaseResponse<OrdersViewModel>> UpdateOrder(int clientId, OrdersViewModel updatedClient);
    }
}
