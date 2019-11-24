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
        return MongoCollection.AsQueryable().Select(x => x == null ? new Movie() :
        new Movie()
        {
          plot = x.plot,
          genres = x.genres.ToList(),
          runtime = x.runtime,
          rated = x.rated,
          cast = x.cast.ToList(),
          poster = x.poster,
          title = Convert.ToString(x.title),
          fullplot = x.fullplot,
          languages = x.languages.ToList(),
          released = x.released,
          directors = x.directors.ToList(),
          writers = x.writers.ToList(),
          awards = x.awards == null ? new Award() :
          new Award()
          {
            wins = x.awards.wins,
            nominations = x.awards.nominations,
            text = x.awards.text
          },
          lastupdated = x.lastupdated,
          year = x.year,
          imdb = x.imdb == null ? new Imdb() :
          new Imdb()
          {
            rating = x.imdb.rating,
            votes = x.imdb.votes,
            id = x.imdb.id
          },
          countries = x.countries.ToList(),
          type = x.type,
          tomatoes = x.tomatoes == null ? new Tomato() :
          new Tomato()
          {
            viewer = x.tomatoes.viewer == null ? new TomatoViewer() :
            new TomatoViewer()
            {
              rating = x.tomatoes.viewer.rating,
              numReviews = x.tomatoes.viewer.numReviews,
              meter = x.tomatoes.viewer.meter
            },
            dvd = x.tomatoes.dvd,
            critic = x.tomatoes.critic == null ? new TomatoCritic() :
            new TomatoCritic()
            {
              rating = x.tomatoes.critic.rating,
              numReviews = x.tomatoes.critic.numReviews,
              meter = x.tomatoes.critic.meter
            },
            production = x.tomatoes.production,
            concensus = x.tomatoes.concensus,
            lastUpdated = x.tomatoes.lastUpdated,
            rotten = x.tomatoes.rotten,
            fresh = x.tomatoes.fresh
          }
        }).ToList();
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
