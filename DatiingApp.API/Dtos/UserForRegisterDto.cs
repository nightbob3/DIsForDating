using System.ComponentModel.DataAnnotations;

namespace DatiingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Put in a longer password numbnuts")]
        public string Password { get; set; }
    }
}