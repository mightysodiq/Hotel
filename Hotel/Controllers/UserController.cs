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

        [HttpPost]
        public IActionResult Login(user users) 
        {
            string connectString = _configuration.GetConnectionString("Default");

            using (SqlConnection con = new SqlConnection(connectString))

            {

                SqlCommand cmd = new();

                cmd.CommandText = "SELECT COUNT(*) FROM UserTable WHERE Email = @Email AND Password = @Password";

                cmd.Connection = con;



                // Add parameters to the command

                cmd.Parameters.AddWithValue("@Email", users.Email); // Provide the email value

                cmd.Parameters.AddWithValue("@Password", _userRepository.HashPassword(users.Password)); // Provide the password value



                con.Open();



                int count = (int)cmd.ExecuteScalar();



                if (count > 0)

                {

                    TempData["success"] = "Login successful";

                    return RedirectToAction("SignUp");

                }

                else

                {

                    // Login failed

                    TempData["error"] = "Incorrect Credentials!";



                }

            }
            return View();
                
        }
        
    }
}
