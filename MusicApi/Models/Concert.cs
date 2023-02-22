namespace MusicApi.Models
{
	public record Concert
	{
		public Guid Id { get; init; }
		public string? Name { get; init; }
		public string? Description { get; set; }
		public DateTimeOffset Date { get; set; }
		public string? Location { get; set; }
		public List<Artist>? Artists { get; set; }
		public List<string>? ArtistsIds { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
	}
}