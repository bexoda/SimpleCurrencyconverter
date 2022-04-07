using Currencyconverter.Data;
using Currencyconverter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Currencyconverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transaction.ToList();
        }

        // POST api/<TransactionController>
        [HttpPost]
        public IEnumerable<Transaction> Createtransact(Transaction transac)
        {
            _context.Transaction.Add(transac);
            _context.SaveChanges();
            return _context.Transaction.ToList();
        }

    }
}
