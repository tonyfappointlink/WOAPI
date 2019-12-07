using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class CompetitionMedias
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MediaId { get; set; }
        public int CompetitionId { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Competitions Competition { get; set; }
    }
}
