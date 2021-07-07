using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel{
        
        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no maximo 80 caracteres")]
        public string Nome { get;  set; }

        [Required(ErrorMessage = "O email não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O email deve no minimo 10 caracteres")]
        [MaxLength(100, ErrorMessage = "O email deve ter no maximo 100 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "A senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A senha deve ter no minimo 6")]
        [MaxLength(100, ErrorMessage = "A senha deve ter no maximo 100 caracteres")]
        public string Password { get; set; }
    }
}