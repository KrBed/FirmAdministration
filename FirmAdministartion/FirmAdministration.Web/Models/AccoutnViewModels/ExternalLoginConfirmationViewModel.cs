using System.ComponentModel.DataAnnotations;

namespace FirmAdministration.Web.Models.AccoutnViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}