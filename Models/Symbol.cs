using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWatchlist.Models
{
    public class Symbol
    {
        public int ID { get; set; }
        [Display(Name = "Symbol")]
        public string? SymbolName {  get; set; }
        public string? Instrument { get; set; }
        public string? Position { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        [Display(Name = "Entry Price")]
        public decimal EntryPrice { get; set; }
        [Display(Name = "Exit Price")]
        public decimal ExitPrice { get; set; }


    }
}
