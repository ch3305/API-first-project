//In C#, each file is named after the class it declares: this file should be UsersController.cs
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Zxcvbn;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //In ASP.NET Core, controller class names end with Controller: UsersController (the route stays api/Users)
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
            //In C#, local variables are camelCase: postUserDetails
            string[] PostUserDetails = new[] { PostUser.email, PostUser.firstname, PostUser.lastname };

            var result = Zxcvbn.Core.EvaluatePassword((PostUser.password).ToString(), PostUserDetails);
            int score = result.Score;
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
            if (user != null)
                return Ok(user);
            //The assignment asks a wrong login to return 204 NoContent: what should this return instead of NotFound?
            return NotFound();

        }
        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest();
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
