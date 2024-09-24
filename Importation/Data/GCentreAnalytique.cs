using GeneraFi.Infrastructure;
using Importation.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importation.Data
{
    class GCentreAnalytique : Repository<CentreAnalytique>
    {
        public GCentreAnalytique() : base("CentreAnalytique", "centreAnaly")
        {
        }
    }
}
