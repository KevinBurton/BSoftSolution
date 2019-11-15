using System;
using Neo4j.Driver.V1;

namespace BSoftSolutions.Interfaces
{
  public interface IGraphDatabase
  {
    IDriver Driver { get; }
  }
}
