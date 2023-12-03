using Employees.DBContext;

namespace Employees.Repository
{
    public class SupervisorRepository: UserRepositoryBase
    {
        public SupervisorRepository(EmployeeDbContext db): base(db)
        {
                
        }
    }
}
