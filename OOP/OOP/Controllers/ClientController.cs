//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors.Infrastructure;
//using Microsoft.AspNetCore.Mvc;
//using OOP.DAL.Interface;
//using OOP.Service.Interfaces;
//using System.Linq;

//namespace OOP.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using OOP.Domain.Response;
//    using OOP.Service.Interfaces;
//    using System.Threading.Tasks;

//    namespace YourNamespace.Controllers
//    {
//        public class ClientController : Controller
//        {
//            private readonly IClientService _clientService;

//            public ClientController(IClientService clientService)
//            {
//                _clientService = clientService;
//            }

//            [HttpGet]
//            public IActionResult GetAllClients()
//            {
//                var response = _clientService.GetAllClients();
//                if (response.StatusCode == Domain.Enum.StatusCode.OK)
//                {
//                    return View(response.Data);
//                }
//                return View("Error", $"{response.Description}");
//            }

//            [HttpGet]
//            public async Task<IActionResult> GetClientById(int clientId)
//            {
//                var response = await _clientService.GetClientById(clientId);
//                if (response.StatusCode == Domain.Enum.StatusCode.Success)
//                {
//                    return View(response.Data);
//                }
//                return View("Error", $"{response.Description}");
//            }

//            //[HttpGet]
//            //public IActionResult Create()
//            //{
//            //    return View();
//            //}

//            [HttpPost]
//            public async Task<IActionResult> Create([FromBody] ClientViewModel client)
//            {
//                //var result = await _clientService.CreateClient(client);

//                //if (result.StatusCode == Domain.Enum.StatusCode.Success)
//                //{
//                    // Возвращаем представление с данными созданного клиента
//                    return View(/*result.Data*/);
//                //}

//               //// Возвращаем представление с ошибкой
//              //  return View("Error", $"{result.Description}");
//            }

//            [HttpGet]
//            public async Task<IActionResult> UpdateClient(int clientId)
//            {
//                var response = await _clientService.GetClientById(clientId);
//                if (response.StatusCode == Domain.Enum.StatusCode.Success)
//                {
//                    return View(response.Data);
//                }
//                return View("Error", $"{response.Description}");
//            }

//            [HttpPost]
//            public async Task<IActionResult> UpdateClient(int clientId, [FromBody] ClientViewModel updatedClient)
//            {
//                var result = await _clientService.UpdateClient(clientId, updatedClient);

//                if (result.StatusCode == Domain.Enum.StatusCode.Success)
//                {
//                    // Возвращаем представление с данными обновленного клиента
//                    return View(result.Data);
//                }

//                // Возвращаем представление с ошибкой
//                return View("Error", $"{result.Description}");
//            }

//            [HttpGet]
//            public async Task<IActionResult> DeleteClient(int clientId)
//            {
//                var response = await _clientService.GetClientById(clientId);
//                if (response.StatusCode == Domain.Enum.StatusCode.Success)
//                {
//                    return View(response.Data);
//                }
//                return View("Error", $"{response.Description}");
//            }

//            [HttpPost]
//            public async Task<IActionResult> ConfirmDeleteClient(int clientId)
//            {
//                var result = await _clientService.DeleteClient(clientId);

//                if (result.StatusCode == Domain.Enum.StatusCode.Success)
//                {
//                    return RedirectToAction("GetAllClients");
//                }

//                // Возвращаем представление с ошибкой
//                return View("Error", $"{result.Description}");
//            }
//        }
//    }

//}
using Microsoft.AspNetCore.Mvc;
using OOP.Domain.Response;
using OOP.Service.Interfaces;
using OOP.Domain.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace OOP.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult GetAllClients()
        {
            var result = _clientService.GetAllClients();
            return View(result.Data); // Предполагается, что возвращаемые данные - это модель для представления
        }

        public IActionResult SearchById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchById(int clientId)
        {
            var result = await _clientService.GetClientById(clientId);
            if (result.Data != null)
            {
                return View("Details", result.Data);
            }
            else
            {
                // Обработка случая, когда клиент не найден
                return View("ClientNotFound");
            }
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ClientViewModel client)
        {
            var result = await _clientService.CreateClient(client);
            if (result.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Обработка ошибок
                return View(client);
            }
        }

        public IActionResult Delete(int id)
        {
            var viewModel = new ClientViewModel { ClientId = id };
            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(ClientViewModel viewModel)
        {
            var result = await _clientService.DeleteClient(viewModel.ClientId);
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
        public async Task<IActionResult> Update(int clientId)
        {
            var result = await _clientService.GetClientById(clientId);
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
        public async Task<IActionResult> Edit(ClientViewModel updatedClient)
        {
            if (ModelState.IsValid)
            {
                var result = await _clientService.UpdateClient(updatedClient.ClientId, updatedClient);
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