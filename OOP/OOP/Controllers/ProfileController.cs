//using Microsoft.AspNetCore.Mvc;
//using OOP.Domain.ViewModel.Profile;
//using OOP.Service.Interfaces;

//namespace OOP.Controllers
//{
//    public class ProfileController : Controller
//    {
//        private readonly IProfileService _profileService;

//        public ProfileController(IProfileService profileService)
//        {
//            _profileService = profileService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Save(ProfileViewModel model)
//        {
//            ModelState.Remove("Id");
//            ModelState.Remove("UserName");

//            if (ModelState.IsValid)
//            {
//                var response = await _profileService.Save(model);

//                if (response.StatusCode == Domain.Enum.StatusCode.OK)
//                {
//                    return Json(new { success = true, description = response.Description });
//                }
//                else
//                {
//                    // Handle other status codes or errors as needed
//                    return Json(new { error = response.Description });
//                }
//            }

//            // If ModelState is not valid, return the validation errors
//            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
//            return Json(new { errors });
//        }



//        public async Task<IActionResult> Detail()
//        {
//            var userName = User.Identity.Name;
//            var response = await _profileService.GetProfile(userName);
//            if (response.StatusCode == Domain.Enum.StatusCode.OK)
//            {
//                return View(response.Data);
//            }
//            return View();
//        }
//    }
//}
