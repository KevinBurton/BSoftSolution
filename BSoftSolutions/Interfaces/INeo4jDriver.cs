using System;
using Neo4j.Driver.V1;

namespace BSoftSolutions.Interfaces
{
  public interface INeo4jDriver
  {
    IDriver Driver { get; }
  }
}
