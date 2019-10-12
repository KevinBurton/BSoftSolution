using System;
using System.Collections.Generic;
using System.Linq;
using BSoftSolutions.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BSoftSolutions.Implementations
{
  public class MongoRepository : IMongoRepository
  {
    string ConnectionString { get;set; }
    MongoClient MongoClient { get;set; }

    public MongoRepository(string cs)
    {
      ConnectionString = cs;
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
      var moviesCollection = MongoClient.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
      foreach(var movie in moviesCollection.Find(new BsonDocument()).ToList())
      {
        yield return movie["title"].ToString();
      }
    }
  }
}
