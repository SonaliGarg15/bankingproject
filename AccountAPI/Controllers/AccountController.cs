using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        
        public AccountController(ILogger<AccountController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hey! I am from account service" };
        }

        [HttpGet("GetAccountInfo/{id}")]
        public string GetAccountInfo()
        {
            throw new KeyNotFoundException("Key is not found");
            try
            {
                logger.LogInformation("Account information found");
                return "Account information is returned";
            }
            catch(Exception ex)
            {
                
                logger.LogError("Account information not found");
                return "Account information not found";
            }
        }

        [HttpGet("GetAccountInfoWithUserId/{id}")]
        public string GetAccountInfoLinkedWithUserId()
        {
            try
            {
                logger.LogInformation("Account information linked with user id found");
                return "Account information linked with user id is returned";
            }
            catch
            {
                logger.LogError("Account information linked with user id not found");
                return "Account information linked with user id not found";
            }
        }

        [HttpGet("GetChequeBookInfoFromAccountId/{id}")]
        public string GetChequeBookInfoFromAccountId()
        {
            try
            {
                logger.LogInformation("Cheque Book information linked with account id found");
                return "Cheque Book information linked with account id is returned";
            }
            catch
            {
                logger.LogError("Cheque Book information linked with account id not found");
                return "Cheque Book information linked with account id not found";
            }
        }

        [HttpPost("BlockChequeBookFromAccountId/{id}")]
        public string BlockChequeBookFromAccountId()
        {
            try
            {
                logger.LogInformation("Cheque Book blocked linked with account id found");
                return "Cheque Book blocked linked with account id is returned";
            }
            catch
            {
                logger.LogError("Cheque Book blocked linked with account id not found");
                return "Cheque Book blocked linked with account id not found";
            }
        }
    }
}
