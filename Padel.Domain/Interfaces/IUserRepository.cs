using Padel.Domain.Entities;

namespace Padel.Domain.Interfaces;
public interface IUserRepository
{
    User? GetById(int id);
    User? GetByEmail(string email);
    User Create(User user);
    void Update(User user);
}