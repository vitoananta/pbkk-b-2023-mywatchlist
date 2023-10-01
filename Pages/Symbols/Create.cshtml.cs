using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWatchlist.Data;
using MyWatchlist.Models;

namespace MyWatchlist.Pages.Symbols
{
    public class CreateModel : PageModel
    {
        private readonly MyWatchlist.Data.MyWatchlistContext _context;

        public CreateModel(MyWatchlist.Data.MyWatchlistContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Symbol Symbol { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Symbol == null || Symbol == null)
            {
                return Page();
            }

            _context.Symbol.Add(Symbol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
