﻿using LSMS.data_access;
using LSMS.Models;
using Microsoft.AspNetCore.Mvc;
using LSMS.Services;
namespace LSMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationService authService;
        private readonly ApplicationDbContext dbContext;

        public LoginController(Services.IAuthenticationService authService ,ApplicationDbContext dbContext)
        {
            this.authService = authService;
            this.dbContext = dbContext;
        }

        public IActionResult Login()
        {
            string username = User.Identity.Name;
            // Retrieve the full professor details from the database using dbContext
            var loggedInProfessor = dbContext.Professors.FirstOrDefault(p => p.SSN == username);

            if (loggedInProfessor != null)
            {
                // Pass the professor model to the view
                return RedirectToAction("Profile", "Professors");
            }
            var loggedInStudent = dbContext.Students.FirstOrDefault(p => p.SSN == username);

            if (loggedInStudent != null)
            {
                // Pass the professor model to the view
                return RedirectToAction("Profile", "Students");
            }
            var loggedInAdmin = dbContext.Admins.FirstOrDefault(p => p.UserName == username);

            if (loggedInAdmin != null)
            {
                // Pass the professor model to the view
                return RedirectToAction("Profile", "Admins");
            }

            return View();
        }

        [HttpPost] 
        public IActionResult Login(string username, string password)
        {
            var professor = authService.AuthenticateProfessor(username, password);

            var student = authService.AuthenticateStudent(username, password);

            var admin = authService.AuthenticateAdmin(username, password);

            if (professor != null)
            {
                authService.SignInProfessor(professor);
                return RedirectToAction("Profile","Professors");
            }

            if (student != null)
            {
                authService.SignInStudent(student);
                return RedirectToAction("Profile","Students");
            }

            if (admin != null)
            {
                authService.SignInAdmin(admin);
                return RedirectToAction("Profile", "Admins");
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }
        public IActionResult Logout()
        {
            authService.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}