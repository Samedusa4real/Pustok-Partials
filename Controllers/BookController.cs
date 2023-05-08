using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokTemplate.DAL;
using PustokTemplate.Models;

namespace PustokTemplate.Controllers
{
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult GetBookDetail(int id)
        {
            Book book = _context.Books
                .Include(x => x.Author)
                .Include(x => x.Images)
                .FirstOrDefault(x => x.Id == id);

            return PartialView("_BookModalPartial", book);
        }
    }
}
