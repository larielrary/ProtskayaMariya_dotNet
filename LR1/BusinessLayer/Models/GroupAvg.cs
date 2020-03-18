using System.Collections.Generic;

namespace LR1.DataLayer
{
    public class GroupAvg
    {
        public IReadOnlyCollection<StudentAvg> StudentAvegareInfos { get; set; }

        public Marks SummaryMarkInfo { get; set; }
    }
}
