using CRUDWithBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithBlazor.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext) 
        { 
            _applicationDbContext = applicationDbContext;
        }
       
        /// <summary>
        /// Get All Employee List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }

        /// <summary>
        /// Add New Employee Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> AddNewEmployee(Employee employee)
        {
             await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get Employee Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeById(int id)
        { 
            Employee employee =await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return employee;
        }

        /// <summary>
        /// Update Employee Data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> UpdateEmployeeDetails(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete Employee Data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
