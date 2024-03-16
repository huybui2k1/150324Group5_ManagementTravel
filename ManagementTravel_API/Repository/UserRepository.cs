using ManagementTravel_API.BusinessObjects;
using ManagementTravel_API.BusinessObjects.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManagementTravel_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ManagementTravelDBContext dbContext;
        public UserRepository(ManagementTravelDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User User)
        {
            await dbContext.Users.AddAsync(User);
            await dbContext.SaveChangesAsync();
            return User;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User?> UpdateAsync(Guid id, User User)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Username = User.Username;
            existingUser.Address = User.Address;
            existingUser.Email = User.Email;

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
