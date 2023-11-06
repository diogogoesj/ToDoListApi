using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;
using ToDoListApi.Repository.Interfaces;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            List<UserModel> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Add(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Modify([FromBody] UserModel userModel, int id)
        {
            userModel.UserId = id;
            UserModel user = await _userRepository.Update(userModel, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Clear(int id)
        {
            bool userDeleted = await _userRepository.Delete(id);

            return Ok(userDeleted);
        }
    }
}
