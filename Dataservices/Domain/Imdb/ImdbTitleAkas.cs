namespace Dataservices.Domain.Imdb
{
    public class ImdbTitleAkas
    {
        public string Tconst { get; set; }
        public int Ordering { get; set; }
        
        public ImdbTitleBasics OriginalTitle { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public bool IsOriginalTitle { get; set; }
        
        
    }
}