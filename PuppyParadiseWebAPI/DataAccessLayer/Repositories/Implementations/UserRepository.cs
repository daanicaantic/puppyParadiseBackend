using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.UserDTOs;
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
        private readonly IMapper _mapper;

        public UserRepository(PuppyParadiseContext puppyParadiseContext, IMapper mapper) : base(puppyParadiseContext)
        {
            _mapper = mapper;
        }

        public async Task<GetUserDTO> GetUserById(int id)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _puppyParadiseContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var user = await _puppyParadiseContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            return user;
        }

        public async Task<User?> GetUserByCredentialsAsync(string email, string password)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}
