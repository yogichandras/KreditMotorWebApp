﻿using KreditMotorDomain.Model.User;
using KreditMotorDomain.Model.User.ManageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace KrediMotorWebApp.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
      
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;

        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public ManageController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
        
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
         
            _logger = logger;
            _urlEncoder = urlEncoder;
        }

        [TempData]
        public string StatusMessage { get; set; }


        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            if (id == null)
            {
                var user = await _userManager.GetUserAsync(User);


                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var hasPassword = await _userManager.HasPasswordAsync(user);
                if (!hasPassword)
                {
                    return RedirectToAction("SetPassword");
                }

                var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
                return View(model);
            }
            else
            {
                var user = await _userManager.FindByIdAsync(id);


                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var hasPassword = await _userManager.HasPasswordAsync(user);
                if (!hasPassword)
                {
                    return RedirectToAction("SetPassword");
                }

                var model = new ChangePasswordViewModel { StatusMessage = StatusMessage, Id_user = id };
                return View(model);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.Id_user == null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    AddErrors(changePasswordResult);
                    return View(model);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation("User changed their password successfully.");
                StatusMessage = "Your password has been changed.";

                return RedirectToAction(nameof(ChangePassword));
            }
            else
            {
                var user = await _userManager.FindByIdAsync(model.Id_user);
                if (user == null)
                {
                    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    AddErrors(changePasswordResult);
                    return View(model);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation("User changed their password successfully.");
                StatusMessage = "Your password has been changed.";

                return RedirectToAction(nameof(ChangePassword));
            }
        }

    

       

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private string FormatKey(string unformattedKey)
        {
            var result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition));
            }

            return result.ToString().ToLowerInvariant();
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                _urlEncoder.Encode("KrediMotorWebApp"),
                _urlEncoder.Encode(email),
                unformattedKey);
        }

        //private async Task LoadSharedKeyAndQrCodeUriAsync(ApplicationUser user, EnableAuthenticatorViewModel model)
        //{
        //    var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
        //    if (string.IsNullOrEmpty(unformattedKey))
        //    {
        //        await _userManager.ResetAuthenticatorKeyAsync(user);
        //        unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
        //    }

        //    model.SharedKey = FormatKey(unformattedKey);
        //    model.AuthenticatorUri = GenerateQrCodeUri(user.Email, unformattedKey);
        //}

        #endregion
    }
}
