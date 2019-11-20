using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSoftSolutions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver.V1;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSoftSolutions.Controllers
{
  [Route("api/graph")]
  public class GraphController : Controller
  {
    private readonly INeo4jDriver graph;
    public GraphController(INeo4jDriver driverInterface)
    {
      graph = driverInterface;
    }
    // GET: api/graph
    [HttpGet("{limit:int?}")]
    public Dictionary<string, List<string>> Index(int limit = 100)
    {
            var statementText = "MATCH (a:Person)-[:ACTED_IN]->(m:Movie) RETURN m.title as movie, collect(a.name) as cast LIMIT {limit}";
            var statementParameters = new Dictionary<string, object> { { "limit", limit } };
            var retVal = new Dictionary<string, List<string>>();
            try
            {
                using (var session = graph.Driver.Session())
                {
                    var result = session.Run(statementText, statementParameters);
                    foreach (var record in result)
                    {
                        retVal[record["movie"].As<string>()] = record["cast"].As<List<string>>();
                    }
                }
            }
            catch (Exception)
            {

            }
            return retVal;
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
