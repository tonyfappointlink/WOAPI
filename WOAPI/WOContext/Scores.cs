using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class Scores
    {
        public int Id { get; set; }
        public int ScorerId { get; set; }
        public int ScoreValue { get; set; }
        public DateTime ScoreTs { get; set; }
        public int CompetitorMediaId { get; set; }

        public virtual CompetitorMedias CompetitorMedia { get; set; }
    }
}
