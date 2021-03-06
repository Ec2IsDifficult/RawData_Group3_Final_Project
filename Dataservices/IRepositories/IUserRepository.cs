namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using CRUDRepository;
    using Domain.User;

    public interface IUserRepository : IMutableRepository<CUser>, IIMutableRepository<CUser>
    {
        public CUser GetReviews(int id);
        CUser GetRatings(int id);
        CUser GetSearchHistory(int id);
        void Rate(string uid, string movieConst, int rating);
        void AddReview(int uid, string movieConst, string review);
        void AddToSearchHistory(int uid, string searchstring);
        void BookmarkPerson(string nConst, int uid, bool alreadyMarked);
        void BookmarkTitle(string tConst, int uid, bool alreadyMarked);
        IEnumerable<CBookmarkTitle> GetTitleBookmarksByUser(int id);
        IEnumerable<CBookmarkPerson> GetPersonBookmarksByUser(int id);
        CUser GetUser(string username);
        void SetNewPassword(int uid, string password);
        void UserUpdateEmail(int uid, string email);
        void CreateUser(string username, string email, string password);
    }
}