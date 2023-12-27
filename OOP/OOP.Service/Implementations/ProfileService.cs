//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using OOP.DAL.Interface;
//using OOP.Domain.Entity;
//using OOP.Domain.Enum;
//using OOP.Domain.Response;
//using OOP.Domain.ViewModel.Profile;
//using OOP.Service.Interfaces;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OOP.Service.Implementations
//{
//    public class ProfileService : IProfileService
//    {
//        private readonly ILogger<ProfileService> _logger;
//        private readonly IBaseRepository<Profile> _profileRepository;

//        public ProfileService(IBaseRepository<Profile> profileRepository, ILogger<ProfileService> logger)
//        {
//            _profileRepository = profileRepository;
//            _logger = logger;
//        }

//        public async Task<BaseResponse<ProfileViewModel>> GetProfile(string userName)
//        {
//            try
//            {
//                var profile = await _profileRepository.GetAll()
//                    .Select(x => new ProfileViewModel
//                    {
//                        Profile_Id = x.profile_id,
//                        Address = x.Address,
//                        Age = x.Age,
//                        UserName = x.User.Name
//                    })
//                    .FirstOrDefaultAsync(x => x.UserName == userName);

//                return new BaseResponse<ProfileViewModel>
//                {
//                    Data = profile,
//                    StatusCode = StatusCode.OK
//                };
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"[ProfileService.GetProfile] error: {ex.Message}");
//                return new BaseResponse<ProfileViewModel>
//                {
//                    StatusCode = StatusCode.InternalServerError,
//                    Description = $"Внутренняя ошибка: {ex.Message}"
//                };
//            }
//        }

//        public async Task<BaseResponse<ProfileViewModel>> Save(ProfileViewModel model)
//        {
//            try
//            {
//                var profile = await _profileRepository.GetAll().FirstOrDefaultAsync(x => x.profile_id == model.Profile_Id);

//                if (profile == null)
//                {
//                    // Создание нового профиля, если не существует
//                    profile = new Profile();
//                }

//                profile.Address = model.Address;
//                profile.Age = model.Age;

//                await _profileRepository.Update(profile);

//                return new BaseResponse<ProfileViewModel>
//                {
//                    Data = new ProfileViewModel
//                    {
//                        Profile_Id = profile.profile_id,
//                        Address = profile.Address,
//                        Age = profile.Age,
//                        UserName = profile.User?.Name
//                    },
//                    Description = "Данные обновлены",
//                    StatusCode = StatusCode.OK
//                };
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, $"[ProfileService.Save] error: {ex.Message}");
//                return new BaseResponse<ProfileViewModel>
//                {
//                    StatusCode = StatusCode.InternalServerError,
//                    Description = $"Внутренняя ошибка: {ex.Message}"
//                };
//            }
//        }
//    }
//}