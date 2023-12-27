using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOP.Domain.ViewModel.EmployeesInProject;
using OOP.Service.Implementations;
using OOP.Service.Interfaces;


    namespace OOP.Controllers
    {
        public class EmployeeInProjectController : Controller
        {
            private readonly IEmployeeInProjectService _employeeInProjectService;

            public EmployeeInProjectController(IEmployeeInProjectService employeeInProjectService)
            {
                _employeeInProjectService = employeeInProjectService;
            }

            public IActionResult GetAll()
            {
                var result = _employeeInProjectService.GetAllEmployeeInProjects();
                return View(result.Data); // Предполагается, что возвращаемые данные - это модель для представления
            }

            public IActionResult SearchById()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> SearchById(int clientId)
            {
                var result = await _employeeInProjectService.GetEmployeeInProjectById(clientId);
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
            public async Task<IActionResult> Create(EmployeeInProjectViewModel employeeInProject)
            {
                var result = await _employeeInProjectService.CreateEmployeeInProject(employeeInProject);
                if (result.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Обработка ошибок
                    return View(employeeInProject);
                }
            }

            public IActionResult Delete(int id)
            {
                var viewModel = new EmployeeInProjectViewModel { assignment_id = id };
                return View(viewModel);
            }

            [HttpPost, ActionName("DeleteConfirmed")]
            public async Task<IActionResult> DeleteConfirmed(EmployeeInProjectViewModel viewModel)
            {
                var result = await _employeeInProjectService.DeleteEmployeeInProject(viewModel.assignment_id);
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
                var result = await _employeeInProjectService.GetEmployeeInProjectById(clientId);
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
            public async Task<IActionResult> Edit(EmployeeInProjectViewModel updatedemployeeInProject)
            {
                if (ModelState.IsValid)
                {
                    var result = await _employeeInProjectService.UpdateEmployeeInProject(updatedemployeeInProject.assignment_id, updatedemployeeInProject);
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
                return View(updatedemployeeInProject);
            }
        }
    }

