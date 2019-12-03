using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Models.Constants;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Web.ViewModels;

namespace MobilePhoneStore.Web.Controllers
{
    public class AccountController : BaseMVCController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext dbContext,
            ILogger<BaseMVCController> logger) : base(dbContext, logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Regex regexEmail = new Regex(Constant.EmailRegex);
                Match matchEmail = regexEmail.Match(model.Username);
                Regex regexPhoneNumber = new Regex(Constant.PhoneNumberRegex);
                Match matchPhoneNumber = regexPhoneNumber.Match(model.Username);
                User user = null;
                if (matchEmail.Success)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                }
                else if (matchPhoneNumber.Success)
                {
                    user = _dbContext.Users.FirstOrDefault(x => x.PhoneNumber == model.Username);
                }
                else
                {
                    return View(model);
                }
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    if (result.IsLockedOut)
                    {
                        return View(model);
                    }
                    else if (result.IsNotAllowed)
                    {
                        return View(model);
                    }
                    else if (result.RequiresTwoFactor)
                    {
                        return View(model);
                    }
                    else if (result.Succeeded)
                    {
                        return RedirectToAction("Home", "Index");
                    }
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Regex regexEmail = new Regex(Constant.EmailRegex);
                Match matchEmail = regexEmail.Match(model.Username);
                Regex regexPhoneNumber = new Regex(Constant.PhoneNumberRegex);
                Match matchPhoneNumber = regexPhoneNumber.Match(model.Username);
                User user = null;
                if (matchEmail.Success)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                }
                else if (matchPhoneNumber.Success)
                {
                    user = _dbContext.Users.FirstOrDefault(x => x.PhoneNumber == model.Username);
                }
                else
                {
                    return View(model);
                }
                if (user != null)
                {
                    return View(model);
                }
                else
                {
                    User newUser = null;
                    if (matchEmail.Success)
                    {
                        newUser = new User
                        {
                            Email = model.Username,
                            UserName = model.Username,
                        };
                    }
                    else if (matchPhoneNumber.Success)
                    {
                        newUser = new User
                        {
                            PhoneNumber = model.Username,
                            UserName = model.Username,
                        };
                    }
                    if (newUser != null)
                    {
                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {

                        }
                        else
                        {
                            return View(model);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Regex regexEmail = new Regex(Constant.EmailRegex);
                Match matchEmail = regexEmail.Match(model.Username);
                Regex regexPhoneNumber = new Regex(Constant.PhoneNumberRegex);
                Match matchPhoneNumber = regexPhoneNumber.Match(model.Username);
                User user = null;
                if (matchEmail.Success)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                }
                else if (matchPhoneNumber.Success)
                {
                    user = _dbContext.Users.FirstOrDefault(x => x.PhoneNumber == model.Username);
                }
                else
                {
                    return View(model);
                }
                if (user != null)
                {
                    if (matchEmail.Success)
                    {

                    }
                    else if (matchPhoneNumber.Success)
                    {

                    }
                }
                else
                {

                }
            }
            return View(model);
        }
    }
}