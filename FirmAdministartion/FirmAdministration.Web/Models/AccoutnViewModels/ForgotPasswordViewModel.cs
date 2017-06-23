using System.ComponentModel.DataAnnotations;

namespace FirmAdministration.Web.Models.AccoutnViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
