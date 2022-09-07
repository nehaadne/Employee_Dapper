using Employee_Dapper.Models;

namespace Employee_Dapper.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetToemployee();
        public Task<Employee> GetEmployee(int id);
        public Task<int> CreateEmployee(Employee employee);
        public Task<int> UpdateEmployee(Employee employee);
        public Task<int> DeleteEmployee(int id);
    }
}
