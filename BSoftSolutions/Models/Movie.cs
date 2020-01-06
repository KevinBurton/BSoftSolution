using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace BSoftSolutions.Models
{
  [BsonIgnoreExtraElements]
  public class TomatoCritic
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public double rating { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int numReviews { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int meter { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class TomatoViewer
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public double rating { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int numReviews { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int meter { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class Tomato
  {
    [BsonElement]
    public TomatoViewer viewer { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string dvd { get; set; }
    [BsonElement]
    public TomatoCritic critic { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string production { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string concensus { get; set; }
    [BsonElement]
    public DateTime lastUpdated { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int rotten { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int fresh { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class Award
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int wins { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int nominations { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string text { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class Imdb
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public double rating { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int votes { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int id { get; set; }
  }
  [BsonIgnoreExtraElements]
  public class Movie
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string plot { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> genres { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int runtime { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string rated { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> cast { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string poster { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string title { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string fullplot { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> languages { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string released { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> directors { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> writers { get; }
    [BsonElement]
    public Award awards { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string lastupdated { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int year { get; }
    [BsonElement]
    public Imdb imdb { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> countries { get; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string type { get; }
    [BsonElement]
    public Tomato tomatoes { get; }
  }
}
