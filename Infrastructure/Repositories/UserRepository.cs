using Balance_API.Domain.Entities;
using Balance_API.Infrastructure.Data;
using Balance_API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly BalanceDbContext _dbContext;

    public UserRepository(BalanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        _dbContext.Users.Remove(user);
    }

    public BalanceDbContext Get_dbContext()
    {
        return _dbContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users
                    .Include(u => u.Cards)
                    .Include(u => u.Transactions)
                    .ToListAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .Include(u => u.Cards)
            .Include(u => u.Transactions)
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.Users
            .Include(u => u.Cards)
            .Include(u => u.Transactions)
            .FirstOrDefaultAsync(x=> x.Id== id);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}