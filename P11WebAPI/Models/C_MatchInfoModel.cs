using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P11WebAPI.Models
{
    public class C_MatchInfoModel
    {
        public int MatchID { get; set; }
        public string MatchLocation { get; set; }
        public int Team1 { get; set; }
        public string Team1Code { get; set; }
        public string Team1Name { get; set; }
        public string Team1Logo { get; set; }
        public int Team2 { get; set; }
        public string Team2Code { get; set; }
        public string Team2Name { get; set; }
        public string Team2Logo { get; set; }
        public System.DateTime MatchDate { get; set; }
        public string Result { get; set; }
        public string TotalOverMatch { get; set; }
        public Nullable<int> LiveWatchingCount { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
        public string MatchBanner { get; set; }
        public string FirstAmpire { get; set; }
        public string SecondAmpire { get; set; }

    }
}