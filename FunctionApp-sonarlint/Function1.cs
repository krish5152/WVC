using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp_sonarlint
{
    public class Function1

    {
        private readonly ILogger<Function1> _logger;


        string password = "password123";
        public Function1(ILogger<Function1> logger)
        {
            int unusedValue = 10;
            _logger = logger;
        }



        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {


            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");


        }
        public int Add(int x, int y)
        {
            return x + 10;  // Only using 'x' and not 'y'
        }

        public void CheckValue(int value)

        {
            if (value > 0)
            {
                // Empty if block - This would trigger a SonarLint warning
            }
            else
            {
                Console.WriteLine("Value is less than or equal to 0.");
            }
        }
    }
}
