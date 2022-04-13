using Microsoft.AspNetCore.Mvc;
using Homework1.Controllers.Model;

namespace Homework1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController
    {
        const double Price_USD = 103.95;
        const double Price_EUR = 114.4;

        [HttpGet("GetPrice")]   
        public Currency? Get(string? Code, int value)
        {
            double cost = 0;
            if (Code == "USD")
                cost = Price_USD;
            else if (Code == "EUR")
                cost = Price_EUR;
            else
               return null;

            return new Currency
            {
                Price = value * cost,
            };
        }

    }
}
