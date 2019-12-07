using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class Competitors
    {
        public Competitors()
        {
            CompetitorMedias = new HashSet<CompetitorMedias>();
            JournalPrefs = new HashSet<JournalPrefs>();
        }

        public int Id { get; set; }
        public string MemberId { get; set; }
        public string Grade { get; set; }
        public string ExamId { get; set; }
        public string GoCard { get; set; }
        public string PacketId { get; set; }
        public string AcceptAgreement { get; set; }
        public int CompetitionId { get; set; }

        public virtual Competitions Competition { get; set; }
        public virtual ICollection<CompetitorMedias> CompetitorMedias { get; set; }
        public virtual ICollection<JournalPrefs> JournalPrefs { get; set; }
    }
}
