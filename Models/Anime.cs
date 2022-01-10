namespace AnimeList.Models;

public class Anime
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool Completed { get; set; }

    public DateTime CreatedAt { get; set; }
}
