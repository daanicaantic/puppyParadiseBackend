using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PuppyParadiseContext puppyParadiseContext) : base(puppyParadiseContext)
        {
        }
        public async Task AddUser(UserDTO userDTO)
        {
            var role = await _puppyParadiseContext.Roles.FirstOrDefaultAsync(r => r.Id == userDTO.RoleId);
            if (role == null)
                throw new Exception("Role not found!");
            var user = new User
            {
                Name = userDTO.Name,
                Surname = userDTO.Surname,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                RoleId = userDTO.RoleId,
            };
            await base.Add(user);
        }
        public async Task<UserDTO> GetUser(int id)
        {
            /*return await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    RoleId = u.RoleId,
                    RoleName = u.Role.Name
                })
                .FirstOrDefaultAsync();*/

            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            if(user == null)
                throw new Exception("User not found!");

            var u = new UserDTO(user.Name, user.Surname, user.Email, user.PhoneNumber, user.RoleId, user.Role.Name);
            return u;
   
        }


        public async Task<User> GetByEmail(string email)
        {
            var user = await  _puppyParadiseContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new Exception("Wrong email!");
            return user;
        }

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            var user = await _puppyParadiseContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null)
                throw new Exception("Wrong phone number!");
            return user;
        }
    }
}
