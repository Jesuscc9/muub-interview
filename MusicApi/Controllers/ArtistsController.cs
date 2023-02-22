using Microsoft.AspNetCore.Mvc;
using MusicApi.Repositories;
using MusicApi.Dtos;
using MusicApi.Models;

namespace MusicApi.Controllers
{
	[ApiController]
	[Route("artists")]
	public class ArtistsController : ControllerBase
	{
		private readonly IArtistRepository repository;

		public ArtistsController(IArtistRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IEnumerable<ArtistDto>> GetArtistsAsync()
		{
			var artists = (await repository.GetArtistsAsync()).Select(artist => artist.AsDto());

			return artists;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ArtistDto>> GetArtistAsync(Guid id)
		{
			var artist = await repository.GetArtistAsync(id);

			if (artist is null)
			{
				return NotFound();
			}

			Console.WriteLine(artist);

			return artist.AsDto();
		}


		[HttpPost]
		[ActionName(nameof(GetArtistAsync))]
		public async Task<ActionResult<ArtistDto>> CreateArtistAsync(CreateArtistDto artistDto)
		{
			string[] emptyArray = new string[0];

			Artist artist = new()
			{
				Id = Guid.NewGuid(),
				Name = artistDto.Name,
				Biography = artistDto.Biography,
				AvatarUrl = artistDto.AvatarUrl,
				Followers = artistDto.Followers,
				CreatedDate = DateTimeOffset.UtcNow,
				ConcertsIds = emptyArray.ToList(),
				Concerts = new List<Concert> { }
			};

			await repository.CreateArtistAsync(artist);

			return CreatedAtAction(nameof(GetArtistAsync), new { id = artist.Id }, artist.AsDto());
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateArtist(Guid id, UpdateArtistDto artistDto)
		{
			var existingArtist = await repository.GetArtistAsync(id);

			if (existingArtist is null)
			{
				return NotFound();
			}

			Artist updatedArtist = existingArtist with
			{
				Name = artistDto.Name,
				Biography = artistDto.Biography,
				AvatarUrl = artistDto.AvatarUrl,
				Followers = artistDto.Followers,
			};

			await repository.UpdateArtistAsync(updatedArtist);

			return NoContent();

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteArtistAsync(Guid id)
		{
			var existingArtist = await repository.GetArtistAsync(id);

			if (existingArtist is null)
			{
				return NotFound();
			}

			await repository.DeleteArtistAsync(id);

			return NoContent();
		}
	}
}