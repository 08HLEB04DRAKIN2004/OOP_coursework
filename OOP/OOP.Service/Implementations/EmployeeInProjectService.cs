using Microsoft.EntityFrameworkCore;
using OOP.DAL.Interface;
using OOP.DAL.Repositories;
using OOP.Domain.Entity;
using OOP.Domain.Enum;
using OOP.Domain.Response;
using OOP.Domain.ViewModel.EmployeesInProject;
using OOP.Service.Interfaces;

namespace OOP.Service.Implementations
{
    public class EmployeeInProjectService : IEmployeeInProjectService
    {
        private readonly IBaseRepository<EmployeeInProject> _employeeInProjectRepository;

        public EmployeeInProjectService(IBaseRepository<EmployeeInProject> employeeInProjectRepository)
        {
            _employeeInProjectRepository = employeeInProjectRepository;
        }

        public IBaseResponse<List<EmployeeInProjectViewModel>> GetAllEmployeeInProjects()
        {
            try
            {
                var employeeInProjects = _employeeInProjectRepository.GetAll();
                var employeeInProjectsViewModel = employeeInProjects.Select(e => new EmployeeInProjectViewModel
                {
                    assignment_id = e.assignment_id,
                    project_id = e.project_id,
                    employee_id = e.employee_id,
                    role_id = e.role_id
                    // Остальные свойства
                }).ToList();

                return new BaseResponse<List<EmployeeInProjectViewModel>>
                {
                    Description = "EmployeeInProjects retrieved successfully",
                    StatusCode = StatusCode.Success,
                    Data = employeeInProjectsViewModel
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<EmployeeInProjectViewModel>>
                {
                    Description = $"Failed to retrieve EmployeeInProjects. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = null
                };
            }
        }

        public async Task<IBaseResponse<EmployeeInProjectViewModel>> GetEmployeeInProjectById(int assignmentId)
        {
            try
            {
                var employeeInProject = await _employeeInProjectRepository.GetAll().FirstOrDefaultAsync(x => x.assignment_id == assignmentId);

                if (employeeInProject != null)
                {
                    var employeeInProjectViewModel = new EmployeeInProjectViewModel
                    {
                        assignment_id = employeeInProject.assignment_id,
                        project_id = employeeInProject.project_id,
                        employee_id = employeeInProject.employee_id,
                        role_id = employeeInProject.role_id
                        // Остальные свойства
                    };

                    return new BaseResponse<EmployeeInProjectViewModel>
                    {
                        Description = "EmployeeInProject retrieved successfully",
                        StatusCode = StatusCode.Success,
                        Data = employeeInProjectViewModel
                    };
                }
                else
                {
                    return new BaseResponse<EmployeeInProjectViewModel>
                    {
                        Description = "EmployeeInProject not found",
                        StatusCode = StatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<EmployeeInProjectViewModel>
                {
                    Description = $"Failed to retrieve EmployeeInProject. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = null
                };
            }
        }

        public async Task<IBaseResponse<EmployeeInProjectViewModel>> CreateEmployeeInProject(EmployeeInProjectViewModel employeeInProject)
        {
            try
            {
                var newEmployeeInProject = new EmployeeInProject
                {
                    project_id = employeeInProject.project_id,
                    employee_id = employeeInProject.employee_id,
                    role_id = employeeInProject.role_id
                    // Остальные свойства
                };

                await _employeeInProjectRepository.Create(newEmployeeInProject);

                var createdEmployeeInProjectViewModel = new EmployeeInProjectViewModel
                {
                    assignment_id = newEmployeeInProject.assignment_id,
                    project_id = newEmployeeInProject.project_id,
                    employee_id = newEmployeeInProject.employee_id,
                    role_id = newEmployeeInProject.role_id
                    // Остальные свойства
                };

                return new BaseResponse<EmployeeInProjectViewModel>
                {
                    Description = "EmployeeInProject created successfully",
                    StatusCode = StatusCode.Success,
                    Data = createdEmployeeInProjectViewModel
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<EmployeeInProjectViewModel>
                {
                    Description = $"Failed to create EmployeeInProject. {ex.Message}",
                    StatusCode = StatusCode.InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteEmployeeInProject(int assignmentId)
        {
            try
            {
                var existingEmployeeInProject = await _employeeInProjectRepository.GetAll().FirstOrDefaultAsync(x => x.assignment_id == assignmentId);

                if (existingEmployeeInProject != null)
                {
                    await _employeeInProjectRepository.Delete(existingEmployeeInProject);

                    return new BaseResponse<bool>
                    {
                        Description = "EmployeeInProject deleted successfully",
                        StatusCode = StatusCode.Success,
                        Data = true
                    };
                }
                else
                {
                    return new BaseResponse<bool>
                    {
                        Description = "EmployeeInProject not found",
                        StatusCode = StatusCode.NotFound,
                        Data = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"Failed to delete EmployeeInProject. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = false
                };
            }
        }

        public async Task<IBaseResponse<EmployeeInProjectViewModel>> UpdateEmployeeInProject(int assignmentId, EmployeeInProjectViewModel updatedEmployeeInProject)
        {
            try
            {
                var existingEmployeeInProject = await _employeeInProjectRepository.GetAll().FirstOrDefaultAsync(x => x.assignment_id == assignmentId);

                if (existingEmployeeInProject != null)
                {
                    existingEmployeeInProject.project_id = updatedEmployeeInProject.project_id;
                    existingEmployeeInProject.employee_id = updatedEmployeeInProject.employee_id;
                    existingEmployeeInProject.role_id = updatedEmployeeInProject.role_id;
                    // Обновление остальных свойств

                    var updatedEntity = await _employeeInProjectRepository.Update(existingEmployeeInProject);

                    var updatedEmployeeInProjectViewModel = new EmployeeInProjectViewModel
                    {
                        assignment_id = updatedEntity.assignment_id,
                        project_id = updatedEntity.project_id,
                        employee_id = updatedEntity.employee_id,
                        role_id = updatedEntity.role_id
                        // Остальные свойства
                    };

                    return new BaseResponse<EmployeeInProjectViewModel>
                    {
                        Description = "EmployeeInProject updated successfully",
                        StatusCode = StatusCode.Success,
                        Data = updatedEmployeeInProjectViewModel
                    };
                }
                else
                {
                    return new BaseResponse<EmployeeInProjectViewModel>
                    {
                        Description = "EmployeeInProject not found",
                        StatusCode = StatusCode.NotFound,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<EmployeeInProjectViewModel>
                {
                    Description = $"Failed to update EmployeeInProject. {ex.Message}",
                    StatusCode = StatusCode.Error,
                    Data = null
                };
            }
        }
    }
}