using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Identity.Services.DTO;

using Identity.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services.Get
{
    public interface IUserQueryService
    {
        Task<List<UserDto>> GetAllAsync();

    }

    public class UserGet : IUserQueryService
    {
        private readonly ApplicationDbContext _context;

        public UserGet(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
