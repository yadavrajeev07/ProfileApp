using Microsoft.AspNetCore.Mvc;
using UserProfileApp.Models;
using UserProfileApp.Services;

namespace UserProfileApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserProfileService _service;

        public UserController(UserProfileService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var users = _service.GetAll();
            return View(users);
        }

        [HttpPost]
        public IActionResult Save(UserProfile profile)
        {
            if (profile.Id == null || profile.Id == MongoDB.Bson.ObjectId.Empty)
                _service.Create(profile);
            else
                _service.Update(profile.Id.ToString(), profile);

            return RedirectToAction("Index");
        }
    }
}
