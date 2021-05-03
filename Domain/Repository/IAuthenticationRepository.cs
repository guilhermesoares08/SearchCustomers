namespace Domain.Repository
{
    public interface IAuthenticationRepository
    {
        UserSys ValidateUser(string email, string password);
        UserSys GetUserByLogin(string login);

    }
}