using MusicApi.Models;

namespace MusicApi.Repositories

{
	public interface IArtistRepository
	{
		Task<Artist> GetArtistAsync(Guid id);
		Task<IEnumerable<Artist>> GetArtistsAsync();
		Task CreateArtistAsync(Artist artist);
		Task UpdateArtistAsync(Artist artist);
		Task DeleteArtistAsync(Guid id);
	}
}