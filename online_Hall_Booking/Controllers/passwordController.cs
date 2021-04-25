using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using online_Hall_Booking.Helpers;
using Microsoft.Extensions.Logging;
using online_Hall_Booking.Models;


namespace Identity.Controllers
{
    [Authorize]
    public class passwordController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private readonly ILogger<passwordController> logger;

        public passwordController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr, ILogger<passwordController> logger)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            this.logger = logger;
        }

        // other codes

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await userManager.FindByEmailAsync(email);
                // If the user is found AND Email is confirmed
                if (user != null && await userManager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "password",
                            new { email = email, token = token }, Request.Scheme);

                    // Log the password reset link
                    EmailHelper emailHelper = new EmailHelper();
                    bool emailResponse = emailHelper.SendEmailPasswordReset(user.Email, passwordResetLink);
                    if (emailResponse)

                        return RedirectToAction("ForgotPasswordConfirmation");
                    else
                    {
                        // log email failed 
                    }
                    // Send the user to Forgot Password Confirmation view
                    return View("ForgotPasswordConfirmation");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return View("ForgotPasswordConfirmation");
            }
            return View(email);
        }

      [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
                return View(resetPassword);

            var user = await userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
                RedirectToAction("ResetPasswordConfirmation");

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                    ModelState.AddModelError(error.Code, error.Description);
                return View();
            }

            return RedirectToAction("ResetPasswordConfirmation");
        }
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }




    }


   
}

