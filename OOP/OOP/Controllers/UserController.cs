using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OOP.Domain.Extensions;
using OOP.Domain.ViewModel.UserViewModel;
using OOP.Service.Interfaces;
using System.Linq;

namespace OOP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Save() => PartialView();
        [HttpPost]
        public async Task<IActionResult> Save(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _userService.Create(model);
                    if (response.StatusCode == Domain.Enum.StatusCode.OK)
                    {
                        return Json(new { description = response.Description });
                    }
                    return BadRequest(new { errorMessage = response.Description });
                }

                var errorMessage = string.Join(", ", ModelState.Values
                    .SelectMany(v => v.Errors.Select(x => x.ErrorMessage)));

                return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage });
            }
            catch (Exception ex)
            {
                // Записываем подробную информацию об ошибке

                // По желанию, можно вернуть ответ об ошибке клиенту
                return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage = "Произошла ошибка при сохранении изменений в базе данных. Пожалуйста, повторите попытку позже." });
            }
        }




        [HttpPost]
        public JsonResult GetRoles()
        {
            var types = _userService.GetRoles();
            return Json(types.Data);
        }
    }
}
