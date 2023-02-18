using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace entity_dotnet_project.Controllers
{
    public class LikeController : Controller
    {
        public IQueryable<Like> Likes;
        public List<User> Users;
        private readonly IUserRepository _userRepo;
        private ILikeRepository _likeRepo;
        public LikeController(ILikeRepository likeRepo , IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _likeRepo = likeRepo;
        }

        public IActionResult Index()
        {
            Likes = _likeRepo.Likes;
            return View(Likes);
        }

        public ViewResult AddLike()
        {
            LikeUserViewModel viewModel = new LikeUserViewModel();
            Users = _userRepo.Users.ToList();
            viewModel.UsersList = new List<SelectListItem>();

            foreach (var user in Users)
            {
               viewModel.UsersList.Add(new SelectListItem {
                    Text = user.Username, Value = user.Id + "-" + user.Username});
            }
            return View("AddLike", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> LikeForm(LikeUserViewModel viewModel)
        {
            var SelectedSender = viewModel.SelectedSender; 
            var SelectedRecipient = viewModel.SelectedRecipient; 
            string[] sender = SelectedSender.Split('-');
            string[] recipient = SelectedRecipient.Split('-');
            Console.WriteLine("Sender Id: " + sender[0]);
            Console.WriteLine("Sender username: " + sender[1]);
            Console.WriteLine("Recipient Id: " + recipient[0]);
            Console.WriteLine("Recipient username: " + recipient[1]);

            var like = new Like 
            {
                SourceUserId = Int32.Parse(sender[0]),
                TargetUserId = Int32.Parse(recipient[0]),
            };

            await _likeRepo.AddAsync(like);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long sourceUserId, long targetUserId)
        {
            Like? k = await _likeRepo.Likes
                .FirstOrDefaultAsync(k => 
                    k.SourceUserId == sourceUserId && k.TargetUserId == targetUserId) ?? new Like();
            if (k != null)
            {
                await _likeRepo.Delete(k);
                return Redirect("~/Like");
            }
            return NotFound();
        }
    }
}