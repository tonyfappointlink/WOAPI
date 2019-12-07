using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class Categories
    {
        public Categories()
        {
            CompetitionMedias = new HashSet<CompetitionMedias>();
        }

        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public int CompetitionId { get; set; }

        public virtual Competitions Competition { get; set; }
        public virtual ICollection<CompetitionMedias> CompetitionMedias { get; set; }
    }
}
