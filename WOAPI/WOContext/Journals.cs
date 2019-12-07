using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class Journals
    {
        public Journals()
        {
            JournalPrefs = new HashSet<JournalPrefs>();
        }

        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public int Limit { get; set; }
        public int LowestRank { get; set; }
        public int WorstPref { get; set; }
        public bool PersonalPaper { get; set; }
        public double PacketWeight { get; set; }
        public double Bbweight { get; set; }
        public double GradeWeight { get; set; }
        public double StatementWeight { get; set; }
        public string LetterText { get; set; }
        public bool AllowStatement { get; set; }
        public int GroupId { get; set; }
        public int CompetitionId { get; set; }

        public virtual Competitions Competition { get; set; }
        public virtual ICollection<JournalPrefs> JournalPrefs { get; set; }
    }
}
