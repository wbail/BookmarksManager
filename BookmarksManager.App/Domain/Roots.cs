using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarksManager.App.Domain
{
    public class Roots
    {
        public BookmarkBar BookmarkBar { get; set; }
        public Other Other { get; set; }
        public Synced Synced { get; set; }
    }
}
