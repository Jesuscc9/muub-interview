using Microsoft.AspNetCore.Mvc;
using MusicApi.Repositories;
using MusicApi.Dtos;
using MusicApi.Models;

namespace MusicApi.Controllers
{
	[ApiController]
	[Route("concerts")]
	public class ConcertsController : ControllerBase
	{
		private readonly IConcertRepository repository;

		public ConcertsController(IConcertRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IEnumerable<ConcertDto>> GetConcertsAsync()
		{
			var concerts = (await repository.GetConcertsAsync()).Select(concert => concert.AsDto());

			return concerts;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ConcertDto>> GetConcertAsync(Guid id)
		{
			var concert = await repository.GetConcertAsync(id);

			if (concert is null)
			{
				return NotFound();
			}

			Console.WriteLine(concert);

			return concert.AsDto();
		}


		[HttpPost]
		[ActionName(nameof(GetConcertAsync))]
		public async Task<ActionResult<ConcertDto>> CreateConcertAsync(CreateConcertDto ConcertDto)
		{
			Concert concert = new()
			{
				Id = Guid.NewGuid(),
				Name = ConcertDto.Name,
				Description = ConcertDto.Description,
				Date = ConcertDto.Date,
				Location = ConcertDto.Location,
				ArtistsIds = ConcertDto.ArtistsIds,
				CreatedDate = DateTimeOffset.UtcNow
			};

			await repository.CreateConcertAsync(concert);

			return CreatedAtAction(nameof(GetConcertAsync), new { id = concert.Id }, concert.AsDto());
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateConcert(Guid id, UpdateConcertDto concertDto)
		{
			var existingConcert = await repository.GetConcertAsync(id);

			if (existingConcert is null)
			{
				return NotFound();
			}

			Concert updatedConcert = existingConcert with
			{
				Name = concertDto.Name,
				Description = concertDto.Description,
				Date = concertDto.Date,
				Location = concertDto.Location,
				ArtistsIds = concertDto.ArtistsIds,
			};

			await repository.UpdateConcertAsync(updatedConcert);

			return NoContent();

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteConcertAsync(Guid id)
		{
			var existingConcert = await repository.GetConcertAsync(id);

			if (existingConcert is null)
			{
				return NotFound();
			}

			await repository.DeleteConcertAsync(id);

			return NoContent();
		}
	}
}