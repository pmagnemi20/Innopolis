using Microsoft.AspNetCore.Mvc;
using Homework1.Controllers.Model;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : Controller
    {
        private readonly CurrencyDbContext _context;
        private readonly ILogger<MyController> _logger;
        private readonly IServiceProvider _serviceProvider;

        public MyController(ILogger<MyController> logger, CurrencyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        const double Price_USD = 103.95;
        const double Price_EUR = 114.4;

        [HttpDelete("{id}")]
        public ActionResult<Currency> DeleteCurrency(int id)
        {
            _logger.LogInformation("Controller called method Delete");
            var cy = _context.Currency.Find(id);

            if (cy is null)
                return NotFound();

            _context.Currency.Remove(cy);
            _context.SaveChanges();

            return cy;
        }

        [HttpPut("{id}")]
        public ActionResult<Currency> PutCurrency(int id, Currency cy)
        {
            _logger.LogInformation("Controller called method Put");
            if (id != cy.Id)
                return BadRequest();

            _context.Entry(cy).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Currency> GetCurrency(int id)
        {
            _logger.LogInformation("Controller called method Get");
            var cy = _context.Currency.Find(id);

            if (cy == null)
                return NotFound();
            return Ok(cy);
        }

        [HttpPost("PostDatatoDB")]
        public ActionResult<Currency> PostCurrency(Currency cy)
        {
            if (cy == null)
                return BadRequest();

            _context.Add(cy);
            _context.SaveChanges();

            return CreatedAtAction(nameof(PostCurrency), new Currency { Id = cy.Id }, cy);
        }

        [HttpGet("GetPrice")]   
        public Currency? Get(string? Code, int value)
        {
            _logger.LogInformation("Controller called method GetPrice");
            double cost = 0;
            if (Code == "USD")
            {
                cost = Price_USD;
            }
            else if (Code == "EUR")
            {
                cost = Price_EUR;
            }
            else
               return null;

            var cy = new Currency
            {
                Price = value * cost,
                CurrencyCode = Code,
                Value = value,
                Date = DateTime.Now.ToString()
            };
            _context.Add(cy);
            _context.SaveChanges();
            return cy;
            
        }

    }
}
