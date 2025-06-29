using Repository.Interfaces;
using Service.Interfaces;
using StudyPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return users;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _unitOfWork.UserRepository.CreateAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _unitOfWork.UserRepository.UpdateAsync(user);
        }

        public async Task<User> LoginByEmailAndPassword(User user)
        {
            var userExist = await _unitOfWork.UserRepository.GetUserByEmailAsync(user.Email);
            //ArgumentNullException.ThrowIfNullOrEmpty(user.Email, "This email does not exist, please sign up for an account.");

            if (userExist == null)
            {
                throw new ArgumentNullException("This email does not exist, please sign up for an account.");
            }
            if (userExist.Password != user.Password)
            {
                throw new ArgumentNullException("Incorrect password, please try again.");
            }
            return userExist;

        }

        public async Task<User> LoginByUsernameAndPassword(User user)
        {
            var userExist = await _unitOfWork.UserRepository.GetUserByUsernameAsync(user.Username);
            

            if (userExist == null)
            {
                throw new ArgumentNullException("This user does not exist, please sign up for an account.");
            }
            if (userExist.Password != user.Password)
            {
                throw new ArgumentNullException("Incorrect password, please try again.");
            }
            return userExist;

        }
    }
}
