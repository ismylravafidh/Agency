using Agency.Core.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Common
{
    public record Portfolio:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
