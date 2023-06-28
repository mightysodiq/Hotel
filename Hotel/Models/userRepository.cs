namespace Hotel.Models
{
    public class userRepository : IUserRepository
    {
        public IEnumerable<user> AllUser =>
            new List<user>()
            {
                new user { Id = 1, FirstName = "Olawale", LastName = "Odeyemi", Email = "Wale@gmail.com", Password = "P1234"},
                 new user { Id = 2, FirstName = "Lucky", LastName = "Otono", Email = "Lucky@gmail.com", Password = "P1234"},
            };
             
        public void MyUser()
        {
            string UserFile = "User.txt";

            StreamWriter writer = new StreamWriter(UserFile);

            foreach (var user in AllUser)
            {
                writer.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Email} {user.Password}");
            }

            writer.Close();

        }
    }
}
