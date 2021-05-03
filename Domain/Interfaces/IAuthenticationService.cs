namespace Domain.Interfaces
{
    public interface IAuthenticationService
    {
        UserSys ValidateUser(string email, string password);
        UserSys GetUserByLogin(string login);
    }
}