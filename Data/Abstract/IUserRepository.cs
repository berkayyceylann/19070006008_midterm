using _19070006008_midterm.Models;

namespace _19070006008_midterm.Data.Abstract
{
    public interface IUserRepository : IRepository<CompanyUser>
    {
        CompanyUser GetUserByUsername(string username);
        CompanyUser GetUserByToken(string token);
    }
}
