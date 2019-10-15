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
    IMongoCollection<BsonDocument> MongoCollection { get;set; }

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

      List<BsonValue> results = new List<BsonValue>();

      try
      {
        results = MongoCollection.AsQueryable<BsonDocument>().Select(x => x["title"]).ToList();
      }
      catch(Exception e)
      {
        /*
             at MongoDB.Bson.Serialization.Serializers.StringSerializer.DeserializeValue(BsonDeserializationContext context, BsonDeserializationArgs args)
             at MongoDB.Bson.Serialization.Serializers.SealedClassSerializerBase`1.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
             at MongoDB.Bson.Serialization.Serializers.SerializerBase`1.MongoDB.Bson.Serialization.IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
             at MongoDB.Driver.Linq.Translators.ProjectedObjectDeserializer.ReadDocument(BsonDeserializationContext context, String currentKey, String scopeKey, ProjectedObject currentObject)
             at MongoDB.Driver.Linq.Translators.ProjectedObjectDeserializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
             at MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize[TValue](IBsonSerializer`1 serializer, BsonDeserializationContext context)\\n" +
             at MongoDB.Bson.Serialization.Serializers.ProjectingDeserializer`2.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)\\n" +
             at MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize[TValue](IBsonSerializer`1 serializer, BsonDeserializationContext context)\\n" +
             at MongoDB.Driver.Core.Operations.CursorBatchDeserializationHelper.DeserializeBatch[TDocument](RawBsonArray batch, IBsonSerializer`1 documentSerializer, MessageEncoderSettings messageEncoderSettings)\\n" +
             at MongoDB.Driver.Core.Operations.AsyncCursor`1.CreateCursorBatch(BsonDocument result)\\n" +
             at MongoDB.Driver.Core.Operations.AsyncCursor`1.ExecuteGetMoreCommand(IChannelHandle channel, CancellationToken cancellationToken)\\n" +
             at MongoDB.Driver.Core.Operations.AsyncCursor`1.GetNextBatch(CancellationToken cancellationToken)\\n" +
             at MongoDB.Driver.Core.Operations.AsyncCursor`1.MoveNext(CancellationToken cancellationToken)\\n" +
             at MongoDB.Driver.Core.Operations.AsyncCursorEnumerator`1.MoveNext()\\n" +
             at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\\n" +
             at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\\n" +
             at BSoftSolutions.Implementations.MongoRepository.MovieList() in /Users/rebeccaannburton/Projects/BSoftSolution/BSoftSolutions/Implementations/MongoRepository.cs:line 102
          */

        System.Diagnostics.Debug.WriteLine(e.ToString());
      }

      return results.OrderBy(x => x.ToString()).Select(x => x.ToString());
    }
    public Dictionary<string, List<string>> MovieCastDictionary()
    {
      var query =
        from d in MongoCollection.AsQueryable<BsonDocument>()
        select d["cast"];

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
