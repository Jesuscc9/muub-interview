namespace MusicApi.Dtos
{
	public record UpdateArtistDto
	{
		public Guid Id { get; init; }
		public string? Name { get; init; }
		public string? Biography { get; set; }
		public string? AvatarUrl { get; set; }
		public decimal Followers { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
	}
}