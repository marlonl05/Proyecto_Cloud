using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaMB.Modelos;

namespace LibreriaMB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLLibreriasController : ControllerBase
    {
        private readonly DataContext _context;

        public BLLibreriasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DALLibrerias
        [Route("/PaginasTotal")]
        [HttpGet]
        public ActionResult<int> TotalPaginas()
        {
            if (_context.Libreria== null)
            {
                return NotFound();
            }
            return _context.Libro.Sum(p=>p.NumeroPag);
        }

    }
}
