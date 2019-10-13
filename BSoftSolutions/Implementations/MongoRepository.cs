using System;
using System.Collections.Generic;
using System.Linq;
using BSoftSolutions.Interfaces;
using BSoftSolutions.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BSoftSolutions.Implementations
{
  public class MongoRepository : IMongoRepository
  {
    string ConnectionString { get; set; }

    MongoClient MongoClient { get; set; }
    string MongoDbName { get; set; }
    string MongoCollectionName { get; set; }
    IMongoDatabase MongoDatabase { get; set; }
    IMongoCollection<BsonDocument> MongoCollection { get;set; }

    public MongoRepository(string cs, string dbName, string collectionName)
    {
      ConnectionString = cs;
      MongoDbName = dbName;
      MongoCollectionName = collectionName;
    }

    public string Database
    {
      get => throw new NotImplementedException();
      set => throw new NotImplementedException();
    }

    public bool Open()
    {
      try
      {
        MongoClient = new MongoClient(ConnectionString);
        MongoDatabase = MongoClient.GetDatabase(MongoDbName);
        MongoCollection = MongoDatabase.GetCollection<BsonDocument>(MongoCollectionName);
      }
      catch (Exception)
      {
        return false;
      }
      return true;
    }

    public void Close()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<string> CollectionList()
    {
      throw new NotImplementedException();
    }

    IEnumerable<string> queryDbList(MongoClient client)
    {
      using (IAsyncCursor<BsonDocument> cursor = client.ListDatabases())
      {
        while (cursor.MoveNext())
        {
          foreach (var doc in cursor.Current)
          {
            yield return doc["name"].ToString(); // database name
          }
        }
      }
    }
    public IEnumerable<string> DatabaseList()
    {
      return queryDbList(MongoClient);
    }

    IEnumerable<string> queryCollectionList(IMongoDatabase db)
    {
      using (IAsyncCursor<string> cursor = db.ListCollectionNames())
      {
        while (cursor.MoveNext())
        {
          foreach (var doc in cursor.Current)
          {
            yield return doc; // database name
          }
        }
      }
    }
    public IEnumerable<string> CollectionList(string dbName)
    {
      IMongoDatabase db = MongoClient.GetDatabase(dbName);
      return queryCollectionList(db);
    }
    public IEnumerable<string> MovieList()
    {

      List<BsonValue> results = new List<BsonValue>();

      try
      {
        results = MongoCollection.AsQueryable<BsonDocument>().Select(x => x["title"]).ToList();
      }
      catch(Exception e)
      {
        System.Diagnostics.Debug.WriteLine(e.ToString());
      }

      return results.OrderBy(x => x.ToString()).Select(x => x.ToString());
    }
  }
}
