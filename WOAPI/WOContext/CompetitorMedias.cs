using System;
using System.Collections.Generic;

namespace WOAPI.WOContext
{
    public partial class CompetitorMedias
    {
        public CompetitorMedias()
        {
            Scores = new HashSet<Scores>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadTime { get; set; }
        public int MediaId { get; set; }
        public string Type { get; set; }
        public int CompetitorId { get; set; }

        public virtual Competitors Competitor { get; set; }
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
