using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWatchlist.Data;
using MyWatchlist.Models;

namespace MyWatchlist.Pages.Symbols
{
    public class DeleteModel : PageModel
    {
        private readonly MyWatchlist.Data.MyWatchlistContext _context;

        public DeleteModel(MyWatchlist.Data.MyWatchlistContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Symbol Symbol { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Symbol == null)
            {
                return NotFound();
            }

            var symbol = await _context.Symbol.FirstOrDefaultAsync(m => m.ID == id);

            if (symbol == null)
            {
                return NotFound();
            }
            else 
            {
                Symbol = symbol;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Symbol == null)
            {
                return NotFound();
            }
            var symbol = await _context.Symbol.FindAsync(id);

            if (symbol != null)
            {
                Symbol = symbol;
                _context.Symbol.Remove(Symbol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
