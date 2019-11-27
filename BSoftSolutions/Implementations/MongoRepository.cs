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
    IMongoCollection<BsonDocument> MongoCollection { get;set; }

    public MongoRepository(string cs, string dbName, string collectionName)
    {
      BsonClassMap.RegisterClassMap<Movie>();
      BsonClassMap.RegisterClassMap<Tomato>();
      BsonClassMap.RegisterClassMap<TomatoCritic>();
      BsonClassMap.RegisterClassMap<TomatoViewer>();
      BsonClassMap.RegisterClassMap<Award>();
      BsonClassMap.RegisterClassMap<Imdb>();
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
        var cursor = MongoCollection.Find(new BsonDocument()).ToCursor();
        var movieList = new List<Movie>();
        foreach (var document in cursor.ToEnumerable())
        {
          var movie = new Movie()
          {
            plot = document.Contains("plot") ? document["plot"].AsString : string.Empty,
            runtime = document.Contains("runtime") ? document["runtime"].ToInt32() : 0,
            rated = document.Contains("rated") ? document["rated"].AsString : string.Empty,
            poster = document.Contains("posted") ? document["posted"].AsString : string.Empty,
            title = document.Contains("fullplot") ? document["fullplot"].AsString : string.Empty,
            released = document.Contains("released") ? document["released"].AsString : string.Empty,
            lastupdated = document.Contains("lastupdated") ? document["lastupdated"].AsString : string.Empty,
            year = document.Contains("year") ? document["year"].ToInt32() : 0,
            type = document.Contains("type") ? document["type"].AsString : string.Empty,
          };
          movie.genres = new List<string>();
          if(document.Contains("genres"))
          {
            var fields = document["genres"].AsBsonArray;
            foreach (var field in fields)
            {
              movie.genres.Add(field.AsString);
            }
          }
          movie.cast = new List<string>();
          if (document.Contains("cast"))
          {
            var fields = document["cast"].AsBsonArray;
            foreach (var field in fields)
            {
              movie.cast.Add(field.AsString);
            }
          }
          movie.languages = new List<string>();
          if (document.Contains("languages"))
          {
            var fields = document["languages"].AsBsonArray;
            foreach (var field in fields)
            {
              movie.languages.Add(field.AsString);
            }
          }
          movie.directors = new List<string>();
          if(document.Contains("directors"))
          {
            var fields = document["directors"].AsBsonArray;
            foreach (var field in fields)
            {
              movie.directors.Add(field.AsString);
            }
          }
          movie.writers = new List<string>();
          if(document.Contains("writers"))
          {
            var fields = document["writers"].AsBsonArray;
            foreach (var field in fields)
            {
              movie.writers.Add(field.AsString);
            }
          }
          movie.countries = new List<string>();
          if(document.Contains("countries"))
          {
            var fields = document["countries"].AsBsonArray;
            foreach (var field in fields)
            {
              movie.countries.Add(field.AsString);
            }
          }

          movie.awards = new Award();
          if(document.Contains("awards"))
          {
            var subDocument = document["awards"].AsBsonDocument;
            //movie.awards.wins = subDocument.Contains("wins") ? (int)subDocument["wins"] : 0;
            //movie.awards.nominations = subDocument.Contains("nominations") ? (int)(subDocument["nominations"].AsDouble) : 0;
            //movie.awards.text = subDocument.Contains("text") ? subDocument["text"].AsString : string.Empty;
          }
          movie.imdb = new Imdb();
          if(document.Contains("imdb"))
          {
            var subDocument = document["imdb"].AsBsonDocument;
            //movie.imdb.rating = subDocument.Contains("rating") ? subDocument["rating"].AsDouble : 0.0;
            //movie.imdb.votes = subDocument.Contains("votes") ? (int)(subDocument["votes"].AsDouble) : 0;
            //movie.imdb.id = subDocument.Contains("id") ? subDocument["id"].AsInt32 : 0;
          }
          movie.tomatoes = new Tomato();
          //if (document.Contains("tomatoes"))
          //{
          //  var subDocument = document["tomatoes"].AsBsonDocument;
          //  if (subDocument.Contains("viewer"))
          //  {
          //    var viewerDocument = subDocument["viewer"].AsBsonDocument;
          //    movie.tomatoes.viewer = new TomatoViewer();
          //    movie.tomatoes.viewer.rating = viewerDocument.Contains("rating") ? viewerDocument["rating"].AsDouble : 0.0;
          //    movie.tomatoes.viewer.numReviews = viewerDocument.Contains("numReviews") ? (int)(viewerDocument["numReviews"].AsDouble) : 0;
          //    movie.tomatoes.viewer.meter = viewerDocument.Contains("meter") ? (int)(viewerDocument["meter"].AsDouble) : 0;
          //  }
          //  movie.tomatoes.dvd = subDocument.Contains("dvd") ? subDocument["dvd"].AsString : string.Empty;
          //  if (subDocument.Contains("critic"))
          //  {
          //    movie.tomatoes.critic = new TomatoCritic();
          //    var criticDocument = subDocument["critic"].AsBsonDocument;
          //    movie.tomatoes.critic.rating = criticDocument.Contains("rating") ? criticDocument["rating"].AsDouble : 0.0;
          //    movie.tomatoes.critic.numReviews = criticDocument.Contains("numReviews") ? criticDocument["numReviews"].AsInt32 : 0;
          //    movie.tomatoes.critic.meter = criticDocument.Contains("meter") ? criticDocument["meter"].AsInt32 : 0;
          //  }
          //  movie.tomatoes.production = subDocument.Contains("production") ? subDocument["production"].AsString : string.Empty;
          //  movie.tomatoes.concensus = subDocument.Contains("consensus") ? subDocument["consensus"].AsString : string.Empty;
          //  movie.tomatoes.lastUpdated = subDocument.Contains("lastUpdated") ? subDocument["lastUpdated"].ToUniversalTime() : DateTime.MinValue;
          //  movie.tomatoes.rotten = subDocument.Contains("rotten") ? subDocument["rotten"].AsInt32 : 0;
          //  movie.tomatoes.fresh = subDocument.Contains("fresh") ? subDocument["fresh"].AsInt32 : 0;
          //}

          movieList.Add(movie);
        }
        return movieList;
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine(e.ToString());
        throw;  
      }
    }
    public Dictionary<string, List<string>> MovieCastDictionary()
    {
      throw new NotImplementedException();
    }
  }
}
