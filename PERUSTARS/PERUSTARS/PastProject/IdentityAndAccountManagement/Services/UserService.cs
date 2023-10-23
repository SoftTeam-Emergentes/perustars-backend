using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AutoMapper;
using PERUSTARS.Domain.Persistence.Repositories;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Authorization.Handlers.Interfaces;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Domain.Services.Communications;
using PERUSTARS.PastProject.IdentityAndAccountManagement.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PERUSTARS.PastProject.IdentityAndAccountManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await  _userRepository.ListAsync();
        }

        public async Task<User> GetByIdAsync(BigInteger id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");
            return user;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByUsernameAsync(request.Username);
            //Console.WriteLine($"Request: {request.Email}, {request.Password}");
            //Console.WriteLine($"User: {user.Id}, {user.Name}, {user.LastName}, {user.PasswordHash}");

            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
            {
                Console.WriteLine("Authentication Error");
                throw new AppException("Username or password is incorrect.");
            }
            Console.WriteLine("Authentication successful. About to generate token.");
            var response = _mapper.Map<AuthenticateResponse>(user);
            Console.WriteLine($"Response: {response.Id}, {response.Username}");
            response.Token = _jwtHandler.GenerateToken(user);
            Console.WriteLine($"Generated Token: {response.Token}");
            return response;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Email '{request.Username}' is already taken.");

            var user = _mapper.Map<User>(request);

            user.PasswordHash = BCryptNet.HashPassword(request.Password);

            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            } 
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var user = await _userRepository.FindByUsernameAsync(username);
            if (user == null)
                return new User();
            return user;
        }

        public async Task UpdateAsync(BigInteger id, UpdateRequest request)
        {

            var user = GetById(id);
            var userWithEmail = await _userRepository.FindByUsernameAsync(request.Username);
        
            if(userWithEmail != null && userWithEmail.Id != user.Id)
                throw new AppException($"Email '{request.Username}' is already taken.");

            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCryptNet.HashPassword(request.Password);

            _mapper.Map(request, user);
            try
            {
                _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");
            }
        }

        public async Task DeleteAsync(BigInteger id)
        {
            var user = GetById(id);
            try
            {
                _userRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");
            }
        }

        private User GetById(BigInteger id)
        {
            var user = _userRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }
    }
}
