using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalLibraryAPI.Data;
using PersonalLibraryAPI.Model;
using PersonalLibraryAPI.DTOs;
using AutoMapper;

namespace PersonalLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BooksController(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTo>>> GetBooks([FromQuery] string? category, [FromQuery] string? search)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(b => b.Category.ToLower() == category.ToLower());
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Title.Contains(search) || b.Author.Contains(search));
            }

            var books = await query.OrderBy(b => b.Title).ToListAsync();
            return Ok(_mapper.Map<List<BookDTo>>(books));
        }

        [HttpGet("${id}")]
        public async Task<ActionResult<BookDTo>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDTo>(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookDTo>> CreateBook(BookCreateDTo bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<BookDTo>(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, result);
        }

        [HttpPut("${id}")]
        public async Task<IActionResult> UpdatedBook(int id, BookUpdateDT bookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, book);
            await _context.SaveChangesAsync();

            return NotFound();
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetCategories()
        {
            var categories = await _context.Books.Select(b => b.Category).Distinct().OrderBy(b => b).ToListAsync();

            return Ok(categories);
        }

        
    }
}