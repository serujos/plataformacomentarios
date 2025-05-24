using Microsoft.AspNetCore.Mvc;
using plataformacomentarios.Data;
using plataformacomentarios.Models;
using Microsoft.EntityFrameworkCore;

namespace plataformacomentarios.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromForm] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { 
                    Message = "Datos inválidos",
                    Errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                });
            }

            var existe = await _context.Feedbacks.AnyAsync(f => f.PostId == feedback.PostId);
            if (existe)
                return BadRequest(new { Message = "Ya diste tu opinión sobre esta noticia." });

            feedback.Fecha = DateTime.UtcNow; 
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            
            return Ok(new { Message = "¡Gracias por tu opinión!" });
        }
        
        

        [HttpGet]
        public async Task<IActionResult> GetAllFeedback()
        {
            var data = await _context.Feedbacks.ToListAsync();
            return Ok(data);
        }
    }
}
