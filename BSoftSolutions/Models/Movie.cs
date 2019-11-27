using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace BSoftSolutions.Models
{
  [Serializable]
  public class TomatoCritic
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public double rating;
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int numReviews;
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int meter;
  }
  [Serializable]
  public class TomatoViewer
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public double rating;
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int numReviews;
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int meter;
  }
  [Serializable]
  public class Tomato
  {
      [BsonElement]
      public TomatoViewer viewer;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string dvd;
      [BsonElement]
      public TomatoCritic critic;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string production;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string concensus;
      [BsonElement]
      public DateTime lastUpdated;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int rotten;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int fresh;
  }
  [Serializable]
  public class Award
  {
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int wins;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int nominations;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string text;
  }
  [Serializable]
  public class Imdb
  {
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
      public double rating;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int votes;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int id;
  }
  [Serializable]
  public class Movie
  {
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string plot;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public IList<string> genres;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int runtime;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string rated;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public IList<string> cast;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string poster;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string title;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string fullplot;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public IList<string> languages;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string released;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public IList<string> directors;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public IList<string> writers;
      [BsonElement]
      public Award awards;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string lastupdated;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
      public int year;
      [BsonElement]
      public Imdb imdb;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public IList<string> countries;
      [BsonElement]
      [BsonRepresentation(MongoDB.Bson.BsonType.String)]
      public string type;
      [BsonElement]
      public Tomato tomatoes;
    }
}
