using MusicApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MusicApi.Repositories
{
	public class MongoDbArtistsRepository : IArtistRepository
	{

		private const string databaseName = "MusicApiDB";
		private const string collectionName = "artists";
		private readonly IMongoCollection<Artist> artistsCollection;
		private readonly FilterDefinitionBuilder<Artist> filterBuilder = Builders<Artist>.Filter;

		public MongoDbArtistsRepository(IMongoClient mongoClient)
		{
			IMongoDatabase database = mongoClient.GetDatabase(databaseName);
			artistsCollection = database.GetCollection<Artist>(collectionName);
		}

		public async Task CreateArtistAsync(Artist artist)
		{
			await artistsCollection.InsertOneAsync(artist);
		}

		public async Task DeleteArtistAsync(Guid id)
		{
			var filter = filterBuilder.Eq(artist => artist.Id, id);
			await artistsCollection.DeleteOneAsync(filter);
		}

		public async Task<Artist> GetArtistAsync(Guid id)
		{
			var filter = filterBuilder.Eq(artist => artist.Id, id);
			return await artistsCollection.Find(filter).SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<Artist>> GetArtistsAsync()
		{
			return await artistsCollection.Find(new BsonDocument()).ToListAsync();
		}


		public async Task UpdateArtistAsync(Artist artist)
		{
			var filter = filterBuilder.Eq(currentartist => currentartist.Id, artist.Id);
			await artistsCollection.ReplaceOneAsync(filter, artist);
		}

	}
}