namespace Hotel.Models
{
    public interface IUserRepository
    {
        string HashPassword(string password);
    }
}
