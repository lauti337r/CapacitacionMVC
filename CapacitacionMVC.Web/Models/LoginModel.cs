namespace CapacitacionMVC.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseņa")]
        public string Password { get; set; }

        [Display(Name = "Recordame")]
        public bool RememberMe { get; set; }
    }
}