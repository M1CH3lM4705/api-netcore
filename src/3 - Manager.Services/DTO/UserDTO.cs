namespace Manager.Services.DTO
{
    public class UserDTO{

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
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