using Microsoft.AspNetCore.Mvc;
using OOP.Domain.Response;
using OOP.Service.Interfaces;
using OOP.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OOP.Domain.ViewModel.Orders;

namespace OOP.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult GetAllOrders()
        {
            var result = _orderService.;
            return View(result.Data); // Предполагается, что возвращаемые данные - это модель для представления
        }

        public IActionResult SearchById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchById(int orderId)
        {
            var result = await _orderService.GetOrderById(orderId);
            if (result.Data != null)
            {
                return View("Details", result.Data);
            }
            else
            {
                // Обработка случая, когда клиент не найден
                return View("OrderNotFound");
            }
        }


        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        public async Task<IActionResult> Create(Orders order)
        {
            var result = await _orderService.CreateOrder(order);
            if (result.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Обработка ошибок
                return View(order);
            }
        }

        public IActionResult Delete(int id)
        {
            var viewModel = new Domain.ViewModel.Orders.Orders { Order_id = id };
            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Domain.ViewModel.Orders.Orders viewModel)
        {
            var result = await _orderService.DeleteOrder(viewModel.Order_id);
            if (result.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return RedirectToAction("Index"); // Перенаправляем на страницу с таблицей всеми элементами
            }
            else
            {
                // Обработка ошибок
                return View("Delete", viewModel);
            }
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int orderId)
        {
            var result = await _orderService.GetOrderById(orderId);
            if (result.StatusCode == Domain.Enum.StatusCode.Success)
            {
                var clientViewModel = result.Data;
                return View("Edit", clientViewModel);
            }
            else
            {
                // Обработка ошибок
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Domain.ViewModel.Orders.Orders updatedClient)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.UpdateOrder(updatedClient.Order_id, updatedClient);
                if (result.StatusCode == Domain.Enum.StatusCode.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Обработка ошибок
                    return View("Error");
                }
            }

            // Если модель недопустима, вернуть представление с моделью
            return View(updatedClient);
        }
    }
}