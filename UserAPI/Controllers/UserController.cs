using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        UserSettings userSettings { get; set; }

        public UserController(IOptions<UserSettings> options, ILogger<UserController> logger)
        {
            userSettings = options.Value;
            this.logger = logger;
        }

        [Route("GetCustomerInfo/{id}")]
        [HttpGet]
        public string GetCustomerInfo()
        {
            try
            {
                logger.LogInformation("Customer information found");
                return "Customer information is returned - " + userSettings.UserAddedSuccessfullyMessage;
            }
            catch
            {
                logger.LogError("Customer information not found");
                return "Customer information not found";
            }
        }

        [Route("AddCustomer")]
        [HttpPost]
        public string AddCustomer([FromBody] string name)
        {
            try
            {
                logger.LogInformation("New customer added name is " + name);
                return "New Customer Added";
            }
            catch
            {
                logger.LogError("Error while adding the customer");
                return "New customer is not added successfully";
            }
        }

        [Route("UpdateCustomer/{id}")]
        [HttpPut]
        public string UpdateCustomer(int id, [FromBody] string value)
        {
            try
            {                
                logger.LogInformation("Updated customer value is " + value);
                return "Customer Updated";
            }
            catch
            {
                logger.LogError("Error while updating the customer");
                return "Customer is not updated successfully";
            }
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                logger.LogInformation("Deleted customer id is " + id);
                return "Customer Deleted";
            }
            catch
            {
                logger.LogError("Error while deleting the customer");
                return "Customer is not deleted successfully";
            }
        }
    }
}
