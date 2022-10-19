using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PracticeMicroservice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAmazonDynamoDB _amazonDynamoDB;
        public UserController(IAmazonDynamoDB amazonDynamoDB)
        {
            _amazonDynamoDB = amazonDynamoDB;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<User>> Get()
        {
            var result = await _amazonDynamoDB.ScanAsync(new ScanRequest
            {
                TableName = "Test"
            });
            var users = new List<User>();
            if(result != null && result.Items != null)
            {
                foreach(var item in result.Items)
                {
                    item.TryGetValue("username", out var username);
                    item.TryGetValue("msg_quota", out var msg_quota);
                    item.TryGetValue("msg_sent", out var msg_sent);

                    users.Add(new User
                    {
                        username = username?.S,
                        msg_quota = msg_quota?.S,
                        msg_sent = msg_sent?.S
                    });
                }
            }
            return users;
        }
    }
}
