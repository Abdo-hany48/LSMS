﻿using LSMS.data_access;
using LSMS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For Session
using LSMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace LSMS.Controllers
{
    public class ProfessorsController : Controller
    {

        private readonly Services.IAuthenticationService authService;
        private readonly ApplicationDbContext dbContext;

        public ProfessorsController(Services.IAuthenticationService authService, ApplicationDbContext dbContext)
        {
            this.authService = authService;
            this.dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var professor = authService.AuthenticateProfessor(username, password);

            if (professor != null)
            {
                authService.SignInProfessor(professor);
                return RedirectToAction("Profile");
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        public IActionResult Profile()
        {
            // Retrieve the currently authenticated professor's username
            string username = User.Identity.Name;

            // Retrieve the full professor details from the database using dbContext
            var loggedInProfessor = dbContext.Professors.FirstOrDefault(p => p.SSN == username);

            if (loggedInProfessor != null)
            {
                // Pass the professor model to the view
                return RedirectToAction("X", "Professors",loggedInProfessor);
            }

            // Handle the case where the professor is not found
            return RedirectToAction("Index", "Home");
        }
        public IActionResult X(Professor professor)
        {
            string username = professor.SSN;
            var loggedInProfessor = dbContext.Professors.FirstOrDefault(p => p.SSN == username);
            if(loggedInProfessor != null)
                return View(loggedInProfessor);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            authService.SignOutProfessor();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
