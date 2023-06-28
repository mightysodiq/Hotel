namespace Hotel.Models
{
    public interface IUserRepository
    {
        IEnumerable<user> AllUser { get; }
        void MyUser();
    }
}
