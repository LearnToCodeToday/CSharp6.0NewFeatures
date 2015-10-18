using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOnCShapr6
{
    public class AutoPropertyIntializer
    {
        public Guid PropertyId { get; } = Guid.NewGuid();
    }
}
