using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task4_userAPI.DataTransferObject;
using Task4_userAPI.Filters;
using Task4_userAPI.Models;

namespace Task4_userAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class userControllers : ControllerBase

    {
        private IUserRepo _userRepo;
        private IMapper _mapper;    
        public userControllers(IUserRepo userRepo,IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;   

        }
        [HttpGet]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<List<UserVM>> getAll()
        {
            var users = _userRepo.getAll();
            var usersVM = _mapper.Map <List<UserVM>> (users);
            return usersVM;
           // return await usersVM;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<UserVM>> get(int id)
        {
            var _user = _userRepo.get(id);
            if (_user == null)
                return NotFound();
            var userVM = _mapper.Map<UserVM>(_user);
            return userVM;
            //return await userVM;
        }

        [HttpDelete]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> Delete(int id)
        {
            var _user = _userRepo.get(id);
            var userVM = _mapper.Map<user>(_user);
            if (userVM == null)
                return NotFound();
            _userRepo.delete(id);
            return Ok();
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async  Task<ActionResult> update(UserVM _user)
        {
            var user = _userRepo.get(_user.Id);
            var userVM = _mapper.Map<user>(user);
            if (userVM == null) return NotFound();
               _userRepo.update(userVM);
            return Ok();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async  Task<ActionResult> create(UserVM _user)
        {
            var user = _mapper.Map<user>(_user);
            _userRepo.add(user);
            return Ok();

        }
    }
}
