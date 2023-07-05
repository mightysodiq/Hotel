using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class user
    {
        public user()
        {
            Id = Guid.NewGuid();
            RegisteredOn = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredOn { get; set; }

        public user(Guid id, string FirstName, string LastName, string Email, string Password, DateTime date)
        {
            
        }
    }
}
