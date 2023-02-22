namespace MusicApi.Dtos
{
	public record UpdateConcertDto
	{
		public string? Name { get; init; }
		public string? Description { get; set; }
		public DateTimeOffset Date { get; set; }
		public string? Location { get; set; }
		public List<string>? ArtistsIds { get; set; }
	}
}