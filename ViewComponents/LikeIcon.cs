using entity_dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace entity_dotnet_project.ViewComponents
{
    public class LikeIcon : ViewComponent
    {
        private readonly ILikeRepository _likeRepo;
        public LikeIcon(ILikeRepository likeRepo)
        {
            _likeRepo = likeRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int likesNumber = await _likeRepo.LikesNumber();
            return View(likesNumber);
        }
    }
}
