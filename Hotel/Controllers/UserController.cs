using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Data.SqlClient;

namespace Hotel.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public UserController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;

        }
        public IActionResult SignUp()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult SignUp(user users)
        {

            string connectString = _configuration.GetConnectionString("Default");

            using (SqlConnection con = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO UserTable(Id, FirstName, LastName, Email, Password, DateTime) " +
                                  "VALUES (@Id, @FirstName, @LastName, @Email, @Password, @DateTime)";
                cmd.Connection = con;

                // Add parameters to the command
                cmd.Parameters.AddWithValue("@Id", users.Id);
                cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
                cmd.Parameters.AddWithValue("@LastName", users.LastName);
                cmd.Parameters.AddWithValue("@Email", users.Email);
                cmd.Parameters.AddWithValue("@Password", _userRepository.HashPassword(users.Password));
                cmd.Parameters.AddWithValue("@DateTime", users.RegisteredOn);

                con.Open();

                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Successful");
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
           /* var allusers = _userRepository.AllUser;*/

            return View();
        }
    }
}
