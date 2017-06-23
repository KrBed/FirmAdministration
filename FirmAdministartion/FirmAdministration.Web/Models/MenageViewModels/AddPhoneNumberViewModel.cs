using System.ComponentModel.DataAnnotations;

namespace FirmAdministration.Web.Models.MenageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}