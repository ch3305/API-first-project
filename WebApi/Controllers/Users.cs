using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Zxcvbn;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//In C#, each file is named after the type it declares: name this file UsersController.cs
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        IUserService _userService;
        public Users(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        static string filePath = "text.txt";
        

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return user;

        }

        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User PostUser)
        {
            //In C#, local variables are written in camelCase: postUserDetails
            string[] PostUserDetails = new[] { PostUser.email, PostUser.firstname, PostUser.lastname };

            //The assignment asks the controller to take the password service's interface and call the strength check through it. Where is that service, and where is the strength route (POST with the password as a JSON string)?
            var result = Zxcvbn.Core.EvaluatePassword((PostUser.password).ToString(), PostUserDetails);
            int score = result.Score;
            //The assignment asks a weak password (score below 3) to return 400: this check refuses only below 2. Which score should be refused?
            if (score < 2)
            {
                return BadRequest(new { message = "הסיסמה חלשה מדי. יש לבחור סיסמה חזקה יותר." });

            }
            _userService.AddUser(PostUser);
            return CreatedAtAction(nameof(Get), new { id = PostUser.id }, PostUser);
        }
        [HttpPost("Login")]
        public ActionResult<User> Post([FromBody] LoginUser PostUser)
        {
            User user = _userService.Login(PostUser);
            //The assignment asks a wrong password to return 204 NoContent: what should this return instead of NotFound?
            if (user != null)
                return Ok(user);
            return NotFound();

        }
        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            //The assignment asks a weak password on PUT to return 400: where should the password check for update go? Use the same check as in POST
            var updated = _userService.Update(user);
            if (!updated)
                return NotFound();

            return Ok(user);
        }
        

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
