using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    public class IndexModel : PageModel
    {
        private readonly MyWatchlist.Data.MyWatchlistContext _context;

        public IndexModel(MyWatchlist.Data.MyWatchlistContext context)
        {
            _context = context;
        }

        public IList<Symbol> Symbol { get;set; } = default!;
        public SelectList Instruments;
        public string SymbolInstrument { get; set; }

        //public async Task OnGetAsync()
        //{
        //    if (_context.Symbol != null)
        //    {
        //        Symbol = await _context.Symbol.ToListAsync();
        //    }
        //}

        public async Task OnGetAsync(string symbolInstrument, string searchString)
        {
            IQueryable<string> instrumentQuery = from m in _context.Symbol
                                                 orderby m.Instrument
                                                 select m.Instrument;

            var symbols = from m in _context.Symbol
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                symbols = symbols.Where(s => s.SymbolName.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(symbolInstrument))
            {
                symbols = symbols.Where(x => x.Instrument == symbolInstrument);
            }
            Instruments = new SelectList(await instrumentQuery.Distinct().ToListAsync());

            Symbol = await symbols.ToListAsync();
        }   
    }
}
