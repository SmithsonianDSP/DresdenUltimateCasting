using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DresdenUltimateCasting.Database;
using Microsoft.AspNetCore.Mvc;

namespace DresdenUltimateCasting.Web.Controllers
{
    public class DuccaController : Controller
    {

        // See Full Sample For Reference https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/data/entity-framework-6/sample/

        private readonly DuccaDbContext _context;

        public DuccaController(DuccaDbContext context)
        {
            _context = context;
        }

    }
}
