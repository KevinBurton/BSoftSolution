using System;
using System.Collections.Generic;

// Shell connection
// mongo "mongodb+srv://bsoftcluster-aa13o.mongodb.net/test"  --username rkevinburton
namespace BSoftSolutions.Interfaces
{
  public interface IMongoRepository
  {
    bool Open();
    void Close();
    IEnumerable<string> DatabaseList();
    IEnumerable<string> CollectionList(string dbName);
  }
}
