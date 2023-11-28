using _19070006008_midterm.Models;
using System.Threading.Tasks;

namespace _19070006008_midterm.Logic.Abstract
{
    public interface IUserManager
    {
        Task<LogicResponseDTO<CompanyUser>> SignUp(SignUpModel model);
        LogicResponseDTO<CompanyUser> SignIn(SignInModel model);
        CompanyUser GetUserFromToken(string token);
    }
}
