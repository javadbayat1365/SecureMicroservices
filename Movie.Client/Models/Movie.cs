namespace Movie.Client.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
