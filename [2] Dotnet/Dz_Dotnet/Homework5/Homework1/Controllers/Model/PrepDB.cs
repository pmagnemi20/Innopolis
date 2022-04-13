using Microsoft.EntityFrameworkCore;

namespace Homework1.Controllers.Model
{
    public static class PrepDB
    {
        public static WebApplicationBuilder PopulateDb(this WebApplicationBuilder builder)
        {
            using var serviceProvider = builder.Services.BuildServiceProvider();

            var context = serviceProvider.GetService<CurrencyDbContext>();

            if (context == null)
                throw new Exception("Context is not created!");

            context.Database.Migrate();

            if(!context.Currency.Any())
            {
                
                var cyArray = new Currency[]
                    {
                        new Currency
                        {
                            Price = 12,
                            CurrencyCode = "sad",
                            Value = 30,
                            Date = DateTime.Now.ToString()
                        }
                    }; 
                context.Currency.AddRange(cyArray);
                context.SaveChanges();
            }

            return builder;
        }
    }
}
