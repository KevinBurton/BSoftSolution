using System;
using BSoftSolutions.Interfaces;
using BSoftSolutions.Models;
using Microsoft.Extensions.Options;
using Neo4j.Driver.V1;

namespace BSoftSolutions.Implementations
{
  public class Neo4jDriver: INeo4jDriver
  {
    internal readonly IDriver _driver;
    public IDriver Driver
    {
      get
      {
        return _driver;
      }
    }

    public Neo4jDriver(IOptions<ConnectionStrings> settings)
    {
      var connectionStrings = settings.Value;

      //Use an IoC container and register as a Singleton
      var url = connectionStrings.Neo4jDbConnectionString;
      var username = connectionStrings.Neo4jDbUsername;
      var password = connectionStrings.Neo4jDbPassword;
      var authToken = AuthTokens.None;

      if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(username))
        authToken = AuthTokens.Basic(username, password);


      _driver = GraphDatabase.Driver(url, authToken);

    }
  }
}
