using Employees.DBContext;

namespace Employees.Repository
{
    public class AdminRepository : UserRepositoryBase
    {
        public AdminRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}