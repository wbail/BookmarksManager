using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarksManager.App.Domain
{
    public class Other
    {
        public List<object> Children { get; set; }
        public string DateAdded { get; set; }
        public string DateModified { get; set; }
        public string Guid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
