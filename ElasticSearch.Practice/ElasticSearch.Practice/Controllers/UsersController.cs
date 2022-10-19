using ElasticSearch.Practice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElasticSearch.Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        public UsersController(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            var response = await _elasticClient.SearchAsync<User>(search => search
                                                              .Index("users")
                                                              .Query(query => query.Term(term => term.Name, id) ||
                                                                       query.Match(match => match.Field(field => field.Name).Query(id))));
            
            return response?.Documents?.FirstOrDefault();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] User user)
        {
            var response = await _elasticClient.IndexAsync<User>(user, idx => idx.Index("users"));
            return response.Id;
        }
    }
}
