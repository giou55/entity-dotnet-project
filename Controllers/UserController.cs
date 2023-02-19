using entity_dotnet_project.Data;
using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace entity_dotnet_project.Controllers
{
    public class UserController : Controller
    {
        public IQueryable<User> Users;
        public IQueryable<Message> Messages;
        private readonly IMessageRepository _messageRepo;
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo, IMessageRepository messageRepo) 
        {
            _messageRepo = messageRepo;
           _userRepo = userRepo; 
        }

        public ViewResult Index()
        {
            Users = _userRepo.Users;
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
                _userRepo.Add(user);
                return Redirect("~/User");
            }
            else
            {
                return View("AddUser");
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            User? u = await _userRepo.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            Messages = _messageRepo.Messages;

            if (u != null)
            {
                await _userRepo.Delete(u);
                ViewData["Message"] = "The user is deleted";
                Users = _userRepo.Users;
                return View("Index", Users);
                //return Redirect("~/User");
            }

            ViewBag.Message = "Hello";
            ViewData["Message"] = "User not found";
            Users = _userRepo.Users;
            return View("Index", Users);
        }
    }
}