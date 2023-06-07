using System.ComponentModel.DataAnnotations;

namespace E_shopping_portal.Models
{
    public class AdminHomeModel
    {
        [Display(Name = "Number of users")]
        public string NumberOfUsers { get; set; }
    }
}