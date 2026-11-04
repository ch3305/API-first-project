using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Zxcvbn;
using Services;
using Enitition;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        IUserService _userService;
        public Users(IUserService userService)
        {
            _userService=userService;
        }
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        static string filePath = "text.txt";
        UserService us=new UserService();   

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = us.GetUserById(id);
            if(user == null)
                return NotFound();
            return user;

        }

        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User PostUser)
        {
            string[] PostUserDetails = new[]{PostUser.email, PostUser.firstname, PostUser.lastname};

            var result=Zxcvbn.Core.EvaluatePassword((PostUser.password).ToString(), PostUserDetails);
            int score=result.Score;
            if(score<2)
            {
                return BadRequest(new { message = "הסיסמה חלשה מדי. יש לבחור סיסמה חזקה יותר." });

            }
            us.AddUser(PostUser);
            return CreatedAtAction(nameof(Get), new { id = PostUser.id }, PostUser);
        }
        [HttpPost("Login")]
        public ActionResult<User> Post([FromBody] LoginUser PostUser)
        {
            User user = us.Login(PostUser);
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
            return us.Update(user);
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            us.DeleteUser(id);
        }
    }
}
