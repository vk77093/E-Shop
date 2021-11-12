using eShop.DataStore.HardCoded;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string userName,[FromQuery] string pwd)
        {
            if(userName =="admin" && pwd == "admin123")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.Email,"admin@gmail.com"),
                    new Claim(ClaimTypes.HomePhone,"1234567891"),
                };
                var userIdentity = new ClaimsIdentity(userClaims, CookieCommon.CookieNameStatic);
                var userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(CookieCommon.CookieNameStatic, userPrincipal);
            }
            return Redirect("/outstandingorders");
        }
        [Route("/logout")]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
