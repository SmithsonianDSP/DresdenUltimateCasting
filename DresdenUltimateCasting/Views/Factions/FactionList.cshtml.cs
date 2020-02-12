using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DresdenUltimateCasting.Database;
using DresdenUltimateCasting.Web.Data;

namespace DresdenUltimateCasting.Web
{
    public class FactionListModel : PageModel
    {
        private readonly DresdenUltimateCasting.Web.Data.DuccaContext _context;

        public FactionListModel(DresdenUltimateCasting.Web.Data.DuccaContext context)
        {
            _context = context;
        }

        public IList<Faction> Faction { get;set; }

        public async Task OnGetAsync()
        {
            Faction = await _context.Factions.ToListAsync();
        }
    }
}
