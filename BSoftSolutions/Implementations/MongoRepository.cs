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
    IMongoCollection<Movie> MongoCollection { get;set; }

    public MongoRepository(string cs, string dbName, string collectionName)
    {
      ConnectionString = cs;
      MongoDbName = dbName;
      MongoCollectionName = collectionName;
    }

    public bool Open()
    {
      try
      {
        MongoClient = new MongoClient(ConnectionString);
        MongoDatabase = MongoClient.GetDatabase(MongoDbName);
        MongoCollection = MongoDatabase.GetCollection<Movie>(MongoCollectionName);
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

    public IEnumerable<string> DatabaseList()
    {
      using (IAsyncCursor<BsonDocument> cursor = MongoClient.ListDatabases())
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

    public IEnumerable<string> CollectionList(string dbName)
    {
      IMongoDatabase db = MongoClient.GetDatabase(dbName);
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
    public IEnumerable<string> MovieList()
    {

      try
      {
        var r = MongoCollection.AsQueryable().Select(x => x.title).ToList().Select(x => Convert.ToString(x)).Cast<string>().OrderBy(x => x).ToList();
        return r;
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine(e.ToString());
        throw;
      }
    }
    public Dictionary<string, List<string>> MovieCastDictionary()
    {
      var query =
        from d in MongoCollection.AsQueryable()
        select d.cast;

      try
      {

        var results = query
          .ToList()
          .SelectMany(a => a.ToString().Split(',',StringSplitOptions.RemoveEmptyEntries))
          .ToList();

        System.Diagnostics.Debug.WriteLine(results.Count());
        //return query.ToDictionary<string, List<string>>();
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine(e.ToString());
      }
      throw new NotImplementedException();
    }
  }
}
