using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Fibonacci : ControllerBase
    {
        [HttpGet("{nb}")]
        public IActionResult Get(int nb)
        {
            if (!(nb >= 1 && nb <= 100)) return Ok(-1);

            if (nb == 1) { return Ok(1); }

            int val1 = 0;
            int val2 = 1;

            for (int i = 2; i <=nb; i++)
            {
                int temp = val1 + val2;
                val1 = val2;
                val2 = temp;
            }

            return Ok(val2);
        }
    }
}
