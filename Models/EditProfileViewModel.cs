using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        public string PhoneNumber { get; set; }
    }
}
