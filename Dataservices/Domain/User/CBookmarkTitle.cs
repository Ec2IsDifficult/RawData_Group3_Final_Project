namespace Dataservices.Domain.User
{
    using Imdb;

    public class CBookmarkTitle
    {
        public string Tconst { get; set; }
        public ImdbTitleBasics Title { get; set; }
        public int UserId { get; set; }
        public CUser User { get; set; }
    }
}