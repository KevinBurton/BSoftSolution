using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace BSoftSolutions.Models
{
  [BsonIgnoreExtraElements]
  public class TomatoCritic
  {
    public double? rating;
    public int? numReviews;
    public int? meter;
  }
  [BsonIgnoreExtraElements]
  public class TomatoViewer
  {
      public double? rating;
      public int? numReviews;
      public int? meter;
  }
  [BsonIgnoreExtraElements]
  public class Tomato
  {
      public TomatoViewer viewer;
      public DateTime? dvd;
      public TomatoCritic critic;
      public string production;
      public string concensus;
      public DateTime? lastUpdated;
      public int? rotten;
      public int? fresh;
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
      public double rating;
      public int votes;
      public int id;
  }
  [BsonIgnoreExtraElements]
  public class Movie
  {
      public string plot;
      public IList<string> genres;
      public int runtime;
      public string rated;
      public IList<string> cast;
      public string poster;
      public string title;
      public string fullplot;
      public IList<string> languages;
      public DateTime released;
      public IList<string> directors;
      public IList<string> writers;
      public Award awards;
      public string lastupdated;
      public int year;
      public Imdb imdb;
      public IList<string> countries;
      public string type;
      public Tomato tomatoes;
  }
}
