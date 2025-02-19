using Padel.Domain.Entities;
using Padel.Domain.Interfaces;
using Padel.Infrastructure.Database;

namespace Padel.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PadelContext _context;

    public UserRepository(PadelContext context)
    {
        _context = context;
    }
    
    public User? GetById(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        return user;
    }

    public User? GetByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    
    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    
    
}