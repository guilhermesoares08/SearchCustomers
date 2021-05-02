namespace Domain.Repository
{
    public interface IAuthenticationRepository
    {
        bool ValidateUser(string email, string password);
    }
}