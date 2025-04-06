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

        public async Task AddUser(User user)
        {
            var role = await _puppyParadiseContext.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
            if (role == null)
                throw new Exception("Role not found!");
            
            user.Role = role;

            await base.Add(user);
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return user;
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
