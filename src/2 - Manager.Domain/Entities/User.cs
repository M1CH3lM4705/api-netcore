using System.Collections.Generic;
using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        //Propriedades
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //EF
        protected User(){}
        public User(string nome, string email, string password)
        {
            Nome = nome;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }


        //Comportamentos
        public void MudarNome(string nome){
            Nome = nome;
            Validate();
        }

        public void MudarSenha(string password){
            Password = password;
            Validate();
        }

        public void AlterarEmail(string email){
            Email = email;
            Validate();
        }


        //Autovalida classe
        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid){
                foreach(var error in validation.Errors){
                    _errors.Add(error.ErrorMessage);
                }
                throw new DomainException("Alguns campos estão invalidos, por favor corrija-os!", _errors);
            }
            return true;
        }
    }
}