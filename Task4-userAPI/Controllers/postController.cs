using Microsoft.AspNetCore.Mvc;
using Task4_userAPI.Models;

namespace Task4_userAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : ControllerBase
    {
        private IpostRepo _postRepo;

        public postController(IpostRepo postRepo)
        {
            _postRepo = postRepo;

        }
        [HttpGet]   
        public ActionResult<List<post>> getAll()
        {
            return Ok(_postRepo.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<post> get(int id)
        {
            var _post = _postRepo.get(id);
            if (_post == null)
                return NotFound();
            return Ok(_post);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var _post = _postRepo.get(id);
            if (_post == null)
                return NotFound();
            _postRepo.delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult update(post _post)
        {
            var post = _postRepo.get(_post.Id);
            if (post == null) return NotFound();
            _postRepo.update(_post);
            return Ok();
        }

        [HttpPost]
        public ActionResult create(post _post)
        {
            _postRepo.add(_post);
            return Ok();

        }

    }
}
