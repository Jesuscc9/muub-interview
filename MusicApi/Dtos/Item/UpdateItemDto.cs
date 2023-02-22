using System.ComponentModel.DataAnnotations;

namespace MusicApi.Dtos
{
	public record UpdateItemDto
	{
		[Required]
		public string Name { get; init; } = null!;

		[Required]
		[Range(1, 1000)]
		public decimal Price { get; init; }
	}
}