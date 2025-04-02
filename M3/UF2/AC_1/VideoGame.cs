public class VideoGame
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public string Studio { get; set; }
    public int TimesRented { get; set; }

    public bool IsRented { get; set; }

    public VideoGame(string title, int releaseYear, string genre, string studio)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Genre = genre;
        Studio = studio;
        TimesRented = 0;
        IsRented = false;
    }

    public override string ToString()
    {
        return $"{Title} ({ReleaseYear}) - {Genre} - {Studio}, Alquilado {TimesRented} veces";
    }
}
