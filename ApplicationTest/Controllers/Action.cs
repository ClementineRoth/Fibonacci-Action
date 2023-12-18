using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Action : ControllerBase
    {
        [HttpGet]
        public ActionResult<Model.Action> Get()
        {

            var actions = new[] { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };

            var prices = new[,]
            {
                { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },
                { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },
                { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 }
            };

            var avgPrices = new double[actions.Length];
            var model = new Model.Action();

            for (int i = 0; i < prices.GetLength(0); i++)
            {
                for (int j = 0; j < avgPrices.Length; j++)
                {
                    avgPrices[j] += prices[i, j];
                }
            }
            int topIndice = 0;
            for (int i = 0; i < avgPrices.Length; i++)
            {
                avgPrices[i] = avgPrices[i] / prices.Length;
                if (avgPrices[i] > avgPrices[topIndice]) topIndice = i;
            }

            model.Name = actions[topIndice];
            model.AvgPrice = avgPrices[topIndice];
            return Ok(model);
        }
    }
}
