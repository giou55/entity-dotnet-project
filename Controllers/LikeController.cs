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
             if (!ModelState.IsValid)
            {
                LikeUserViewModel newViewModel = new LikeUserViewModel();
                Users = _userRepo.Users.ToList();
                newViewModel.UsersList = new List<SelectListItem>();

                foreach (var user in Users)
                {
                newViewModel.UsersList.Add(new SelectListItem {
                        Text = user.Username, Value = user.Id + "-" + user.Username});
                }
                return View("AddLike", newViewModel);
            }

            Likes = _likeRepo.Likes;
 
            var SelectedSender = viewModel.SelectedSender; 
            var SelectedRecipient = viewModel.SelectedRecipient; 
            string[] sender = SelectedSender.Split('-');
            string[] recipient = SelectedRecipient.Split('-');
            var sourceUserId = Int32.Parse(sender[0]);
            var targetUserId = Int32.Parse(recipient[0]);

            if (Likes.Any(x => x.SourceUserId == sourceUserId && x.TargetUserId == targetUserId)) 
            {
                LikeUserViewModel newViewModel = new LikeUserViewModel();
                Users = _userRepo.Users.ToList();
                newViewModel.UsersList = new List<SelectListItem>();

                foreach (var user in Users)
                {
                    newViewModel.UsersList.Add(new SelectListItem {
                    Text = user.Username, Value = user.Id + "-" + user.Username});
                }
                ViewData["Message"] = "You cannot add the same like twice";
                return View("AddLike", newViewModel);
            }

            var like = new Like 
            {
                SourceUserId = sourceUserId,
                TargetUserId = targetUserId,
            };

            await _likeRepo.AddAsync(like);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete([FromQuery]Like l)
        {
            Like? k = await _likeRepo.Likes
                .FirstOrDefaultAsync(k => 
                    k.SourceUserId == l.SourceUserId && k.TargetUserId == l.TargetUserId) ?? new Like();
            if (k != null)
            {
                await _likeRepo.Delete(k);
                return Redirect("~/Like");
            }
            return NotFound();
        }
    }
}