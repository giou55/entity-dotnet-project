using entity_dotnet_project.Data;
using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace entity_dotnet_project.Controllers
{
    public class UserController : Controller
    {
        public IQueryable<User> Users;

        private IUserRepository repository;
        public UserController(IUserRepository userRepo) 
        {
           repository = userRepo; 
        }

        public ViewResult Index()
        {
            Users = repository.Users;
            return View(Users);
        }

        public ViewResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        public IActionResult UserForm(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Add(user);
                return Redirect("~/User");
            }
            else
            {
                return View("AddUser");
            }
        }

        // public async Task<IActionResult> Delete(User user)
        // {
        //     await repository.Delete(user);
        //     return Redirect("~/User");
        // }

        public async Task<IActionResult> Delete(long id)
        {
            User? b = await repository.Users
                .FirstOrDefaultAsync(b => b.Id == id) ?? new User();
            if (b != null)
            {
                await repository.Delete(b);
                return Redirect("~/User");
            }
            return NotFound();
        }
    }
}