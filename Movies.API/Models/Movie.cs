namespace Movies.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Genre{ get; set; } = null!;
		public string Owner { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
