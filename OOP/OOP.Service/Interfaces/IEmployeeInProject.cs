using OOP.Domain.Response;
using OOP.Domain.ViewModel.EmployeesInProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Service.Interfaces
{

        public interface IEmployeeInProjectService
        {
            IBaseResponse<List<EmployeeInProjectViewModel>> GetAllEmployeeInProjects();

            Task<IBaseResponse<EmployeeInProjectViewModel>> GetEmployeeInProjectById(int assignmentId);

            Task<IBaseResponse<EmployeeInProjectViewModel>> CreateEmployeeInProject(EmployeeInProjectViewModel employeeInProject);

            Task<IBaseResponse<bool>> DeleteEmployeeInProject(int assignmentId);

            Task<IBaseResponse<EmployeeInProjectViewModel>> UpdateEmployeeInProject(int assignmentId, EmployeeInProjectViewModel updatedEmployeeInProject);
        }

}
