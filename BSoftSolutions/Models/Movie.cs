using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BSoftSolutions.Models
{
  [BsonIgnoreExtraElements]
  public class TomatoViewer
  {
      public float rating { get; set; }
      public int numReviews { get; set; }
      public int meter { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class Tomato
  {
      public TomatoViewer viewer;
      public string production;
      public long lastUpdated;
  }
  [BsonIgnoreExtraElements]
  public class Award
  {
      public int wins;
      public int nominations;
      public string text;
  }
  [BsonIgnoreExtraElements]
  public class Imdb
  {
      public float rating { get; set; }
      public int votes { get; set; }
      public int id { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class Movie
  {
    public Movie()
    {
    }
      [BsonId]
      public ObjectId _id { get; set; }
      public string plot { get; set; }
      public string[] genres { get; set; }
      public int runtime { get; set; }
      public string[] cast { get; set; }
      public string title { get; set; }
      public string fullplot { get; set; }
      public string[] languages { get; set; }
      public long released { get; set; }
      public string[] directors { get; set; }
      public string[] writers { get; set; }
      public Award awards { get; set; }
      public string lastupdated { get; set; }
      public int year { get; set; }
      public Imdb imdb;
      public string[] countries { get; set; }
      public string type;
      public Tomato tomatoes;
  }
}
