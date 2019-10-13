using System;
namespace BSoftSolutions.Models
{
  public class ConnectionStrings
  {
    public string MongoDbConnectionString { get; set; }
    public string AzureStorageAccountContainer { get; set; }
    public string MongoDbName { get; set; }
    public string MongoCollectionName { get; set; }
  }
}
