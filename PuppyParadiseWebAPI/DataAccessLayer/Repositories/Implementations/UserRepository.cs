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

        public async Task<User> GetUser(int id)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }


        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await  _puppyParadiseContext.Users
                .Select(x=>new UserDTO
                {
                    Name=x.Name,
                    Surname=x.Surname,
                    Email=x.Email,
                    PhoneNumber=x.PhoneNumber,
                    RoleName=x.Role.Name,
                    RoleId=x.Role.Id
                })
                .FirstOrDefaultAsync(u => u.Email == email);
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
