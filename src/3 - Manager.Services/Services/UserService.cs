using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EscNet.Cryptography.Interfaces;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly IRijndaelCryptography _rijndaelCryptography;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, IRijndaelCryptography rijndaelCryptography)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _rijndaelCryptography = rijndaelCryptography;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if(userExists != null){
                throw new DomainException("Ja existe um usuario cadastrado com o email informado.");
            }
            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.MudarSenha(_rijndaelCryptography.Encrypt(user.Password));

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if(userExists == null){
                throw new DomainException("Não existe nenhum usuário com o id informado");
            }
            
            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.MudarSenha(_rijndaelCryptography.Encrypt(user.Password));

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
           var allUsers = await _userRepository.GetAll();

           return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }


        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByNome(string nome)
        {
            var allUsers = await _userRepository.SearchByName(nome);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

    }
}