using Employees.Models;
using Employees.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRepositoryBase _userRepository;

        public HomeController(ILogger<HomeController> logger, UserRepositoryBase userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignInOrRegister(User user)
        {
            // Handle sign in or registration logic based on user.Role
            // For simplicity, you can redirect to appropriate actions or handle it in the same action
            int roleId = user.RoleId;
            user.Email = user.Username + "@gmail.com";
            user.isActive = true;// Access the selected RoleId here
            _userRepository.RegisterUser(user);
            // Handle sign in or registration logic based on roleId
            if (roleId == 1)
            {
                // Admin logic
                //_userRepository.RegisterUser(user);
            }
            else if (roleId == 2)
            {

                //_userRepository.RegisterUser(user);
            }
            else if (roleId == 3)
            {
                // User logic
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SignIn()
        {
           
            return View();
        }

        public IActionResult Users(User user)
        {
            User? user2 = _userRepository.GetUserByUsername(user.Username);
            if (user2 == null || user.Password!=user2.Password)
            {
                TempData["ErrorMessage"] = "User not found. Please check your username or password";
                return RedirectToAction("SignIn");
            }
            if (!user2.isActive)
            {
                TempData["ErrorMessage"] = "User is set inactive contact Admin";
                return RedirectToAction("SignIn");

            }

            switch (user2.RoleId)
            {
                case 1: // Admin
                    return RedirectToAction("Admin");

                case 2: // Supervisor
                    return RedirectToAction("Supervisor");

                case 3: // User
                    
                    return RedirectToAction("Agents");

                default:
                    // Handle unknown role
                    return RedirectToAction("UnknownRole");
            }    
            return View(user2);
        }

        public IActionResult Admin()
        {
            List<User> users = _userRepository.GetUsers().ToList();
            return View(users);
        }

        public IActionResult Supervisor()
        {
            List<User> users = _userRepository.GetUsers().Where(x=>x.RoleId != 1).ToList(); 
            return View(users);
        }
        public IActionResult Agents()
        {
            List<User> users = _userRepository.GetUsers().Where(x => x.RoleId == 3).ToList();
            return View(users);
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult UnknownRole()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            User user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return RedirectToAction("Error");
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User updatedUser,  string returnUrl)
        {
            _userRepository.UpdateUser(updatedUser);

            return Redirect(returnUrl);
        }
        public IActionResult ToggleActive(int id, string returnUrl)
        {
            _userRepository.ToggleUserActiveStatus(id);

            return RedirectToAction(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}