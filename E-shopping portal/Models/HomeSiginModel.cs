using System.ComponentModel.DataAnnotations;

namespace E_shopping_portal.Models
{
    public class HomeSiginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}