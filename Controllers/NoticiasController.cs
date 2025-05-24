using Microsoft.AspNetCore.Mvc;
using plataformacomentarios.Services;

namespace plataformacomentarios.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly JsonPlaceholderService _jsonService;

        public NoticiasController(JsonPlaceholderService jsonService)
        {
            _jsonService = jsonService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _jsonService.GetPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Detalle(int id)
        {
            var post = await _jsonService.GetPostByIdAsync(id);
            var user = await _jsonService.GetUserByIdAsync(post.userId);
            var comments = await _jsonService.GetCommentsByPostIdAsync(id);

            ViewBag.Autor = user;
            ViewBag.Comentarios = comments;

            return View(post);
        }
    }
}
