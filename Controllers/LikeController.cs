using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace entity_dotnet_project.Controllers
{
    [Route("[controller]")]
    public class LikeController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public LikeController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}