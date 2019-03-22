﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Username should be at least 5 characters long")]
        [MaxLength(30, ErrorMessage = "Username shouldn't be longer than 30 characters")]
        public string Username { get; set; }
    }
}