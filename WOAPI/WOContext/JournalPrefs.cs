using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class JournalPrefs
    {
        public int Id { get; set; }
        public string Rank { get; set; }
        public int CompetitionMemberId { get; set; }
        public int JournalId { get; set; }

        public virtual Competitors CompetitionMember { get; set; }
        public virtual Journals Journal { get; set; }
    }
}
