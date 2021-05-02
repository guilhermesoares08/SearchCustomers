namespace Domain.Interfaces
{
    public interface IAuthenticationService
    {
        bool ValidateUser(string email, string password);
    }
}