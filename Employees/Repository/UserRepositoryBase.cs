using Employees.DBContext;
using Employees.Models;

namespace Employees.Repository
{
    public class UserRepositoryBase
    {
        protected readonly EmployeeDbContext _dbContext;

        public UserRepositoryBase(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
        public void UpdateUser(User updatedUser)
        {
            var existingUser = _dbContext.Users.Find(updatedUser.UserId);

            if (existingUser != null)
            {
                // Update user details
                existingUser.Username = updatedUser.Username;
                existingUser.Email = updatedUser.Email;
                existingUser.isActive = updatedUser.isActive;
                _dbContext.SaveChanges();
            }
        }
        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
        }
        public void ToggleUserActiveStatus(int userId)
        {
            var user = _dbContext.Users.Find(userId);

            if (user != null)
            {
                // Toggle active status
                user.isActive = !user.isActive;
                _dbContext.SaveChanges();
            }
        }
        public void RegisterUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        // Add other common methods as needed
        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }


    }
}
