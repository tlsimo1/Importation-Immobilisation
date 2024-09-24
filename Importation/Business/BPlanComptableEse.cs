using Data;
using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Business
{
    public class BPlanComptableEse : BusinessBase<PlanComptableEse>
    {
        public BPlanComptableEse() : base(new GPlanComptableEse())
        {
        }
      
    }
}
