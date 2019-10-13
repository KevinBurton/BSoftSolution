using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace BSoftSolutions.Models
{
  [BsonIgnoreExtraElements]
  public class TomatoViewer
  {
      public float rating;
      public int numReviews;
      public int meter;
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
      public float rating;
      public int votes;
      public int id;
  }
  [BsonIgnoreExtraElements]
  public class Movie
  {
      public string plot;
      public IEnumerable<string> genres;
      public int runtime;
      public IEnumerable<string> cast;
      public string title;
      public string fullplot;
      public IEnumerable<string> languages;
      public long released;
      public IEnumerable<string> directors;
      public IEnumerable<string> writers;
      public Award awards;
      public string lastupdated;
      public int year;
      public Imdb imdb;
      public IEnumerable<string> countries;
      public string type;
      public Tomato tomatoes;
  }
}
