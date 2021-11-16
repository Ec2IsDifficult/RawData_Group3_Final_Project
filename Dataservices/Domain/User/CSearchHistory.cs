using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    using System;

    public class CSearchHistory
    {
        public int UserId{ get; set; }
        public string SearchPhrase { get; set; }
        public DateTime SearchHistoryTimeStamp { get; set; }
        //create object cycle
        //public CUser User {get; set;}
    }
}