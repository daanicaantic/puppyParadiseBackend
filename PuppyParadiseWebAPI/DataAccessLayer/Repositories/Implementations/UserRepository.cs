using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using DomainLayer.DTOs.UserDTOs;
using DomainLayer.Helpers;
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

        public async Task<User> GetUserById(int id)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var user = await _puppyParadiseContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            return user;
        }

        public async Task<PagedResult<GetUserDTO>> GetUsersPerPageAsync(UserFilterDTO usersFilter)
        {
            var query = _puppyParadiseContext.Users
                .Include(u => u.Role)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(usersFilter.Search))
            {
                var words = usersFilter.Search.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                query = query.Where(u =>
                    words.All(word =>
                        u.Name.ToLower().Contains(word.ToLower()) ||
                        u.Surname.ToLower().Contains(word.ToLower()) ||
                        u.PhoneNumber.ToLower().Contains(word.ToLower()) ||
                        u.Email.ToLower().Contains(word.ToLower())
                    )
                );
            }

            if (usersFilter.RoleId.HasValue)
            {
                query = query.Where(u => u.RoleId == usersFilter.RoleId.Value);
            }

            var totalCount = await query.CountAsync();

            var users = await query
                .Skip((usersFilter.Page - 1) * usersFilter.PageSize)
                .Take(usersFilter.PageSize)
                .ToListAsync();

            return new PagedResult<GetUserDTO>
            {
                Items = _mapper.Map<List<GetUserDTO>>(users),
                TotalCount = totalCount,
                Page = usersFilter.Page,
                PageSize = usersFilter.PageSize
            };
        }

    }
}
