using Employees.DBContext;

namespace Employees.Repository
{
    public class UserRepository : UserRepositoryBase
    {
        public UserRepository(EmployeeDbContext db): base(db)
        {
                
        }
    }
}
