using Microsoft.AspNetCore.Mvc;
using MovieStore.External.Interfaces;

namespace MovieStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalController : ControllerBase
    {
        private readonly IExternalPostService _postService;

        public ExternalController(IExternalPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetExternalPosts()
        {
            var posts = await _postService.GetPostsAsync();
            return Ok(posts);
        }
    }
}
