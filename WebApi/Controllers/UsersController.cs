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
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string>Get()
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
        public async Task<ActionResult<User>> Post([FromBody] User PostUser)
        {
            var result = Zxcvbn.Core.EvaluatePassword((PostUser.Password));

            if (result.Score <2)
            {
                return BadRequest(new { message = "הסיסמה חלשה מדי. יש לבחור סיסמה חזקה יותר." });

            }
            await _userService.AddUser(PostUser);
            return CreatedAtAction(nameof(Get), new { id = PostUser.Id }, PostUser);

        }
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Post([FromBody] LoginUser PostUser)
        {
            User user = _userService.Login(PostUser);
            if (user != null)
                return Ok(user);
            return NotFound();

        }
        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            var updated = await _userService.Update(user);
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
