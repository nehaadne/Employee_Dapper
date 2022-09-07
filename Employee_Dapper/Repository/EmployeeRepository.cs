using Dapper;
using Employee_Dapper.Context;
using Employee_Dapper.Models;
using Employee_Dapper.Repository.Interface;

namespace Employee_Dapper.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployee(Employee employee)
        {
            int result = 0;
            var query = @"insert into Employee(ename,salary) 
                        values(@ename,@salary)
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, employee);
                return result;
            }
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var query = @"Delete from Employee WHERE Id=@id";
            using(var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var query = "SELECT * FROM Employee WHERE Id=@id";
            using(var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query, new { id = id });
                return employees.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Employee>> GetToemployee()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            int result = 0;
            var query = @"UPDATE Employee SET ename=@ename,
                        salary=@salary where id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, employee);
                return result;
            }

        }
    }
}
