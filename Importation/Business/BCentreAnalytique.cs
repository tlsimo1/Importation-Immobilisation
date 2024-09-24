using GeneraFi.Infrastructure;
using Importation.Data;
using Importation.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importation.Business
{
    class BCentreAnalytique : BusinessBase<CentreAnalytique>
    {
        public BCentreAnalytique() : base(new GCentreAnalytique())
        {
        }
    }
}
