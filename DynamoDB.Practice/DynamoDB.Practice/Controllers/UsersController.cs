using Amazon;
using Amazon.Auth.AccessControlPolicy;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Util;
using DynamoDB.Practice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AmazonDynamoDBClient _DbClient;

        public UsersController(IOptions<DynamoDBConfig> dynamoConfig)
        {
            var Config = ValidateAndGetConfig(dynamoConfig);
            _DbClient = new AmazonDynamoDBClient(new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(Config.AWSRegion)
            });
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            #region IAmazonDynamoDB
            //var result = await _amazonDynamoDB.ScanAsync(new ScanRequest
            //{
            //    TableName = "test"
            //});
            //var users = new List<User>();
            //if (result != null && result.Items != null)
            //{
            //    foreach (var item in result.Items)
            //    {
            //        item.TryGetValue("username", out var username);
            //        item.TryGetValue("msg_quota", out var msg_quota);
            //        item.TryGetValue("msg_sent", out var msg_sent);



            //        users.Add(new User
            //        {
            //            username = username?.S,
            //            msg_quota = msg_quota?.S,
            //            msg_sent = msg_sent?.S
            //        });
            //    }
            //}
            #endregion

            DynamoDBContext Context = new DynamoDBContext(_DbClient);
            var dynamoOpConfig = new DynamoDBOperationConfig { Conversion = DynamoDBEntryConversion.V2 };
            var Result = await Context.ScanAsync<User>(null, dynamoOpConfig).GetRemainingAsync();

            return Result;
        }


        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private DynamoDBConfig ValidateAndGetConfig(IOptions<DynamoDBConfig> dynamoConfig)
        {
            if (dynamoConfig != null && dynamoConfig.Value != null && !string.IsNullOrEmpty(dynamoConfig.Value.AWSRegion))
            {
                return dynamoConfig.Value;
            }
            throw new Exception("Invalid Config");
        }
    }
}