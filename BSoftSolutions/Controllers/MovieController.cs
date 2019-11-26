using System;
using System.Linq;
using System.Collections.Generic;
using BSoftSolutions.Implementations;
using BSoftSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSoftSolutions.Controllers
{
  [Route("Movie")]
  public class MovieController : ControllerBase
  {
    private ConnectionStrings ConnectionStrings { get; set; }
    public MovieController(IOptions<ConnectionStrings> settings)
    {
      ConnectionStrings = settings.Value;
    }
    // GET: /DatabaseList
    [HttpGet]
    [Route("DatabaseList")]
    public IEnumerable<string> DBList()
    {
        var repository = new MongoRepository(ConnectionStrings.MongoDbConnectionString,ConnectionStrings.MongoDbName, ConnectionStrings.MongoCollectionName);
        repository.Open();
        return repository.DatabaseList();
    }
    // GET: /MovieList
    [HttpGet]
    [Route("MovieList")]
    public List<Movie> MovieList()
    {

      var repository = new MongoRepository(ConnectionStrings.MongoDbConnectionString, ConnectionStrings.MongoDbName, ConnectionStrings.MongoCollectionName);
      try
      {
        repository.Open();
        var r = repository.MovieList();
        return r;
      }
      catch(Exception)
      {
        return new List<Movie>();
      }
      finally
      {
        if(repository != null)
        {
          repository.Close();
        }
      }
    }
    // GET: /MovieCastDictionary
    [HttpGet]
    [Route("MovieCastDictionary")]
    public Dictionary<string, List<string>> MovieCastDictionary()
    {
      var repository = new MongoRepository(ConnectionStrings.MongoDbConnectionString, ConnectionStrings.MongoDbName, ConnectionStrings.MongoCollectionName);
      repository.Open();
      return repository.MovieCastDictionary();
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
