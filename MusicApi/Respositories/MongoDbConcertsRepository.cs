using MusicApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;


namespace MusicApi.Repositories
{
	public class MongoDbConcertsRepository : IConcertRepository
	{

		private const string databaseName = "MusicApiDB";
		private const string collectionName = "concerts";
		private readonly IMongoCollection<Concert> concertsCollection;
		private readonly IMongoCollection<Concert> artistsCollection;
		private readonly FilterDefinitionBuilder<Concert> filterBuilder = Builders<Concert>.Filter;

		public MongoDbConcertsRepository(IMongoClient mongoClient)
		{
			IMongoDatabase database = mongoClient.GetDatabase(databaseName);
			concertsCollection = database.GetCollection<Concert>(collectionName);
			artistsCollection = database.GetCollection<Concert>("artists");
		}

		public async Task CreateConcertAsync(Concert concert)
		{
			await concertsCollection.InsertOneAsync(concert);
		}

		public async Task DeleteConcertAsync(Guid id)
		{
			var filter = filterBuilder.Eq(concert => concert.Id, id);
			await concertsCollection.DeleteOneAsync(filter);
		}

		public async Task<Concert> GetConcertAsync(Guid id)
		{
			var filter = filterBuilder.Eq(artist => artist.Id, id);
			return await concertsCollection.Find(filter).SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<Concert>> GetConcertsAsync()
		{

			var lookup = new BsonDocument("$lookup", new BsonDocument {
					{ "from", "artists" },
					{ "localField", "ArtistsIds" },
					{ "foreignField", "_id" },
					{ "as", "Artists" }
			});

			var pipeline = new BsonDocument[] { lookup };

			var results = await concertsCollection.Aggregate<Concert>(pipeline).ToListAsync();

			return results;

		}

		public async Task UpdateConcertAsync(Concert concert)
		{
			var filter = filterBuilder.Eq(concert => concert.Id, concert.Id);
			await concertsCollection.ReplaceOneAsync(filter, concert);
		}

	}
}

