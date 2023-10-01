using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWatchlist.Data;
using MyWatchlist.Models;

namespace MyWatchlist.Pages.Symbols
{
    public class EditModel : PageModel
    {
        private readonly MyWatchlist.Data.MyWatchlistContext _context;

        public EditModel(MyWatchlist.Data.MyWatchlistContext context)
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

            var symbol =  await _context.Symbol.FirstOrDefaultAsync(m => m.ID == id);
            if (symbol == null)
            {
                return NotFound();
            }
            Symbol = symbol;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Symbol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymbolExists(Symbol.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SymbolExists(int id)
        {
          return (_context.Symbol?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
