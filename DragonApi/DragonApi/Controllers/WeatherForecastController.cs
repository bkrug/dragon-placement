using Microsoft.AspNetCore.Mvc;

namespace DragonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var customer1 = new Customer1();
            var customer2 = new Customer2();
            var customer3 = new Customer3();
            var customers = new ICustomer[] { customer1, customer2, customer3 };

            //DOSN'T COMPILE: var discount1 = customer1.GetLoyaltyDiscount();
            var discount2 = customer2.GetLoyaltyDiscount();
            //DOSN'T COMPILE: var discount3 = customer3.GetLoyaltyDiscount();
            var discounts = customers.Select(c => c.GetLoyaltyDiscount()).ToList();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public interface ICustomer
    {
        DateTime DateJoined { get; }
        string Name { get; }
        // 👇 Provide a body for the new method
        decimal GetLoyaltyDiscount()
        {
            var twoYearsAgo = DateTime.UtcNow.AddYears(-2);
            if (DateJoined < twoYearsAgo)
            {
                // Customers who joined > 2 years ago get a 10% discount
                return 0.10m;
            }

            // Otherwise no discount
            return 0;
        }
    }

    public class Customer1 : ICustomer
    {
        public DateTime DateJoined { get; set; }
        public string Name { get; set; } = string.Empty;
    }


    public class Customer2 : ICustomer
    {
        public DateTime DateJoined { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal GetLoyaltyDiscount() => 2;
    }

    public class Customer3 : ICustomer
    {
        public DateTime DateJoined { get; set; }
        public string Name { get; set; } = string.Empty;
        decimal ICustomer.GetLoyaltyDiscount() => 3;
    }
}
