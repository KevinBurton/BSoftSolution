using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace BSoftSolutions.Models
{
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
  public class Movie
  {
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string plot { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> genres { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int runtime { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string rated { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> cast { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string poster { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string title { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string fullplot { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> languages { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string released { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> directors { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> writers { get; set; }
    [BsonElement]
    public Award awards { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string lastupdated { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int year { get; set; }
    [BsonElement]
    public Imdb imdb { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IList<string> countries { get; set; }
    [BsonElement]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public string type { get; set; }
    [BsonElement]
    public Tomato tomatoes { get; set; }
  }
}
