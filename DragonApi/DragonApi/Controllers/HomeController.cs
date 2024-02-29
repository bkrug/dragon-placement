using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DragonApi.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [Authorize]
        [HttpPost("setcookie")]
        public async Task<ActionResult> SignInWithCookie()
        {
            await HttpContext.SignInAsync(
              CookieAuthenticationDefaults.AuthenticationScheme,
              HttpContext.User);

            return NoContent();
        }
    }
}
