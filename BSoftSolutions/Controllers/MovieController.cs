using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSoftSolutions.Implementations;
using BSoftSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSoftSolutions.Controllers
{
  [ApiController]
  [Route("Movie")]
  public class MovieController : ControllerBase
  {
    private ConnectionStrings ConnectionStrings { get; set; }
    public MovieController(IOptions<ConnectionStrings> settings)
    {
      ConnectionStrings = settings.Value;
    }
    // GET: /DBList
    [HttpGet]
    [Route("DBList")]
    public IEnumerable<string> DBList()
    {
        var repository = new MongoRepository(ConnectionStrings.MongoDbConnectionString,ConnectionStrings.MongoDbName, ConnectionStrings.MongoCollectionName);
        repository.Open();
        return repository.DatabaseList();
    }
    // GET: /MovieList
    [HttpGet]
    [Route("")]
    [Route("MovieList")]
    public IEnumerable<string> MovieList()
    {
      var repository = new MongoRepository(ConnectionStrings.MongoDbConnectionString, ConnectionStrings.MongoDbName, ConnectionStrings.MongoCollectionName);
      repository.Open();
      return repository.MovieList();
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
