using Ecommerce.Comment.Context;
using Ecommerce.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Comment Added");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Comment Deleted");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Comment Updated");
        }
        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }
    }
}
