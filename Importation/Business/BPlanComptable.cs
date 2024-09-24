using Data;
using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class BPlanComptable : BusinessBase<PlanComptable>
    {
        public BPlanComptable() : base(new GPlanComptable())
        {
        }
    }
}
