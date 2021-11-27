using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarksManager.App.Domain
{
    public class Root
    {
        public string Checksum { get; set; }
        public Roots Roots { get; set; }
        public string SyncMetadata { get; set; }
        public int Version { get; set; }
    }
}
