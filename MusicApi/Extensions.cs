using MusicApi.Dtos;
using MusicApi.Models;

namespace MusicApi
{
	public static class Extensions
	{
		public static ItemDto AsDto(this Item item)
		{
			return new ItemDto
			{
				Id = item.Id,
				Name = item.Name,
				Price = item.Price,
				CreatedDate = item.CreatedDate
			};
		}

		public static ArtistDto AsDto(this Artist artist)
		{
			return new ArtistDto
			{
				Id = artist.Id,
				Name = artist.Name,
				Biography = artist.Biography,
				AvatarUrl = artist.AvatarUrl,
				Followers = artist.Followers,
				Concerts = artist.Concerts,
				ConcertsIds = artist.ConcertsIds,
				CreatedDate = artist.CreatedDate
			};
		}
		public static ConcertDto AsDto(this Concert concert)
		{
			return new ConcertDto
			{
				Id = concert.Id,
				Name = concert.Name,
				Description = concert.Description,
				Date = concert.Date,
				Location = concert.Location,
				Artists = concert.Artists,
				ArtistsIds = concert.ArtistsIds,
				CreatedDate = concert.CreatedDate
			};
		}
	}
}