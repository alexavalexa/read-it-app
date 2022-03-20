using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ReadIt.Models;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadIt.Models.DTO;
using Microsoft.AspNetCore.Identity;
using ReadIt.Models.Entities;

namespace ReadIt.Controllers
{
    public class AccountControler : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountControler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (userDTO.Password != userDTO.ConfirmPassword)
            {
                //throw new ArgumentException("Please, check your password again and confirm it correctly!");
                return View();
            }

            User user = new User();
            user.Email = userDTO.Email;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;

            IdentityResult result = await userManager.CreateAsync(user, userDTO.Password);
            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            List<IdentityError> errors = new List<IdentityError>(result.Errors);
            ViewData["errors"] = errors;

            return View();
        }
        
        

            public IActionResult Login()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["errorMessage"] = "Username or password is incorrect!";

            return View();
        }

        public IActionResult Logout()
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    } 

