using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class Competitions
    {
        public Competitions()
        {
            Categories = new HashSet<Categories>();
            CompetitionMedias = new HashSet<CompetitionMedias>();
            Competitors = new HashSet<Competitors>();
            Journals = new HashSet<Journals>();
        }

        public int Id { get; set; }
        public string GroupId { get; set; }

        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<CompetitionMedias> CompetitionMedias { get; set; }
        public virtual ICollection<Competitors> Competitors { get; set; }
        public virtual ICollection<Journals> Journals { get; set; }
    }
}
