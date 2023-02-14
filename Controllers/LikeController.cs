using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace entity_dotnet_project.Controllers
{
    public class LikeController : Controller
    {
        public IQueryable<Like> Likes;

        private ILikeRepository repository;
        public LikeController(ILikeRepository likeRepo)
        {
            repository = likeRepo;
        }

        public IActionResult Index()
        {
            Likes = repository.Likes;
            return View(Likes);
        }

        public ViewResult AddLike()
        {
            return View("AddLike");
        }
    }
}