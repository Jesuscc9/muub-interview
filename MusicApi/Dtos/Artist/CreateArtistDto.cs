using System.ComponentModel.DataAnnotations;

namespace MusicApi.Dtos
{
	public record CreateArtistDto
	{
		[Required]
		public string? Name { get; init; }
		[Required]
		public string? Biography { get; set; }
		public string? AvatarUrl { get; set; }
		public decimal Followers { get; set; }
	}
}