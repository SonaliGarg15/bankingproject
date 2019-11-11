using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hey! I am from transaction api" };
        }

        [HttpGet("GetTransactionHistory/{id}")]
        public string GetTransactionHistory()
        {
            try
            {
                logger.LogInformation("Transaction history information found");
                return "Transaction history information is returned";
            }
            catch
            {
                logger.LogError("Transaction history information not found");
                return "Transaction history information not found";
            }
        }

        [HttpGet("GetAllMoney/{id}")]
        public string GetAllMoney()
        {
            try
            {
                logger.LogInformation("Money information found for given account");
                return "Money information is returned";
            }
            catch
            {
                logger.LogError("Money information for given account not found");
                return "Money information for given account not found";
            }
        }
    }
}
