using System;
using System.Collections.Generic;
using System.Linq;
using BSoftSolutions.Interfaces;
using BSoftSolutions.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
      BsonClassMap.RegisterClassMap<Movie>();
      //BsonClassMap.RegisterClassMap<Tomato>();
      //BsonClassMap.RegisterClassMap<TomatoCritic>();
      //BsonClassMap.RegisterClassMap<TomatoViewer>();
      //BsonClassMap.RegisterClassMap<Award>();
      //BsonClassMap.RegisterClassMap<Imdb>();
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
        throw;
      }
      return true;
    }

    public void Close()
    {
      MongoClient = null;
      MongoDatabase = null;
      MongoCollection = null;
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
    public List<Movie> MovieList()
    {

      try
      {
        var r = MongoCollection.AsQueryable<Movie>().ToList();
        return r;
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine(e.ToString());
        throw;  
      }
    }
    public Dictionary<string, List<string>> ActorMovieDictionary()
    {
            try
            {
                var actorMovieDictionary = new Dictionary<string, List<string>>();
                foreach(var movie in MongoCollection.AsQueryable<Movie>())
                {
                    if( movie.cast != null && movie.cast.Any() && !string.IsNullOrWhiteSpace(movie.title) )
                    {
                        foreach(var actor in movie.cast)
                        {
                            if(actorMovieDictionary.ContainsKey(actor))
                            {
                                actorMovieDictionary[actor].Add(movie.title);
                            }
                            else
                            {
                                actorMovieDictionary.Add(actor, new List<string>() { movie.title });
                            }
                        }
                    }
                }
                return actorMovieDictionary;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
