using ArticleWeb.Auth.Service;
using ArticleWeb.Auth.User;

using AspNetCore.Identity.Mongo.Model;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;

namespace ArticleWeb.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Default")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<MongoUser> _userManager;
        private readonly SignInManager<MongoUser> _signInManager;

        public UsersController(UserManager<MongoUser> userManager, SignInManager<MongoUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new MongoUser() { Email = model.Email, UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    var token = JwtHelper.GenerateJwtToken(user.UserName);
                    var viewUser = new ViewUser() { Email = user.Email, UserName = user.UserName, Token = token };
                    return Created("api/register", viewUser);
                }
                return Ok(string.Join(",", result.Errors?.Select(error => error.Description)));
            }
            string errorMessage = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            return BadRequest(errorMessage ?? "Bad Request");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LogUser model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    var token = JwtHelper.GenerateJwtToken(model.UserName);
                    var viewUser = new ViewUser() { Email = "", UserName = model.UserName, Token = token };
                    return Ok(viewUser);
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordUser forgotPasswordUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(forgotPasswordUser.UserName);

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Users", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(user.Email, "ResetPassword", $"Reset Password  {callbackUrl}");
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordUser reserPasswordUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(reserPasswordUser.UserId);

                var result = await _userManager.ResetPasswordAsync(user, reserPasswordUser.Code, reserPasswordUser.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}