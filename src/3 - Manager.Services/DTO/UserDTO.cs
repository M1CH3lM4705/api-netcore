using System.Text.Json.Serialization;

namespace Manager.Services.DTO
{
    public class UserDTO{

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }

        public UserDTO()
        { }

        public UserDTO(long id, string nome, string email, string password)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
        }
    }
}