namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Domain.FunctionObjects;
    using Microsoft.EntityFrameworkCore;

    public class TitleRepository : ImmutableRepository<ImdbTitleBasics>, ITitleRepository
    {
        
        public TitleRepository(ImdbContext context) :base(context)
        {
            
        }
        
        //implemented in controller
        public IEnumerable<ImdbTitleBasics> GetTitlesByYear(int year)
        {
            return ImdbContext.ImdbTitleBasics.Where(x => x.StartYear == year);
        }

        //implemented in controller
        public ImdbTitleBasics GetCast(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Cast).FirstOrDefault(x => x.Tconst == id);
        }
        //implemented in controller
        public ImdbTitleBasics GetCrew(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Crew).FirstOrDefault(x => x.Tconst == id);
        }
        
        //implemented in controller
        public ImdbTitleRatings GetRating(string id)
        {
            return ImdbContext.ImdbTitleRatings.FirstOrDefault(x => x.Tconst == id);
        }

        //same as GetEpisodes ??
        public IEnumerable<ImdbTitleBasics> GetSeasons(string id)
        {
            //TODO: Probably should be created using an SQL function
            return ImdbContext.ImdbTitleBasics.Include(x => x.Episodes);
        }

        //implemented in controller
        public IEnumerable<ImdbTitleBasics> GetTitlesBetween(int startYear, int endYear)
        {
            //TODO: Probably should be created using an SQL function
            return ImdbContext.ImdbTitleBasics.Where(x => x.StartYear >= startYear && x.StartYear <= endYear);
        }

        //implemented in controller
        public ImdbTitleBasics GetEpisodes(string id)
        {
            return ImdbContext.ImdbTitleBasics.Include(x => x.Episodes).FirstOrDefault(x => x.Tconst == id);
        }
    
        
        public IQueryable<MoviesByGenre> GetMoviesByGenre(string name)
        {
            return ImdbContext.MoviesByGenres.FromSqlInterpolated($"select * from similar_movies_genre({name})");
        }
        
        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}