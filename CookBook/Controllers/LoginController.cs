using Context;
using Context.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookBook.Controllers {
    [Route("[controller]")]
    public class LoginController : Controller {
        Connection Connection { get; set; } = new Connection(Startup.Configuration["ConnectionStrings:Default"]);
        [HttpGet]
        public IActionResult Authorization() {
            return View();
        }
        [Route("Authorization")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorization(User userdata) {
            if (userdata.UsLogin == null || userdata.UsPassword == null)
                return Redirect("/login");
            var user = Connection.User.FirstOrDefault(x => x.UsLogin.ToLower() == userdata.UsLogin.ToLower() && x.UsPassword.ToLower() == userdata.UsPassword.ToLower());
            if (user == null)
                return Redirect("/login");

            var claims = new List<Claim>{
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UsLogin)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            return Redirect("/");
        }
        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout() {
            try {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            return Redirect("/login");
        }
    }
}
