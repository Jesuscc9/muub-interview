using MusicApi.Models;

namespace MusicApi.Repositories

{
	public interface IConcertRepository
	{
		Task<Concert> GetConcertAsync(Guid id);
		Task<IEnumerable<Concert>> GetConcertsAsync();
		Task CreateConcertAsync(Concert Concert);
		Task UpdateConcertAsync(Concert Concert);
		Task DeleteConcertAsync(Guid id);
	}
}