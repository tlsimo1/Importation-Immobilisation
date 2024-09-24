using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
   public class GPlanComptable: Repository<PlanComptable>
    {
        public GPlanComptable() : base("PlanComptable", "numCompte")
        {
        }
    }
}
