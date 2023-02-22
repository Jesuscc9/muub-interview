using MusicApi.Models;

namespace MusicApi.Dtos
{
	public record ArtistDto
	{
		public Guid Id { get; init; }
		public string? Name { get; init; }
		public string? Biography { get; set; }
		public string? AvatarUrl { get; set; }
		public decimal Followers { get; set; }
		public List<Concert>? Concerts { get; set; }
		public List<string>? ConcertsIds { get; set; }
		public DateTimeOffset CreatedDate { get; set; }

	}
}