using System;
using System.ComponentModel.DataAnnotations;

namespace E_shopping_portal.Models
{
    public class HomeSignupModel
    {

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Select your date of birth")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please choose your gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Adddress")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please slect your state")]
        [Display(Name = "State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please select your city")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }



    }
}