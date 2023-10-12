using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataOrders.Data;

namespace ODataOrders;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ODataController
{
    private readonly ODataOrdersContext _context;

    public CustomersController(ODataOrdersContext context)
    {
        _context = context;
    }

    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_context.Customers);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Customer customer)
    {
        _context.Add(customer);

        await _context.SaveChangesAsync();

        return Ok(customer);
    }

    private readonly List<string> demoCustomers = new List<string>
    {
        "Foo",
        "Bar",
        "Acme",
        "King of Tech",
        "Awesomeness"
    };

    private readonly List<string> demoProducts = new List<string>
    {
        "Bike",
        "Car",
        "Apple",
        "Spaceship"
    };

    private readonly List<string> demoCountries = new List<string>
    {
        "AT",
        "DE",
        "CH"
    };

    [HttpPost]
    [Route("fill")]
    public async Task<IActionResult> Fill()
    {
        var rand = new Random();
        for(var i = 0; i < 10; i++)
        {
            var c = new Customer
            {
                CustomerName = demoCustomers[rand.Next(demoCustomers.Count)],
                CountryId = demoCountries[rand.Next(demoCountries.Count)]
            };
            _context.Customers.Add(c);

            for(var j = 0; j < 10; j++)
            {
                var o = new Order
                {
                    OrderDate = DateTime.Today,
                    Product = demoProducts[rand.Next(demoProducts.Count)],
                    Quantity = rand.Next(1, 5),
                    Revenue = rand.Next(100, 5000),
                    Customer = c
                };
                _context.Orders.Add(o);
            }
        }

        await _context.SaveChangesAsync();
        return Ok();
    }
}
