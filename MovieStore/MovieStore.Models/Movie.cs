namespace MovieStore.Models
{
    public class Movie
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        public List<string> Actors { get; set; } = new();
    }
}
