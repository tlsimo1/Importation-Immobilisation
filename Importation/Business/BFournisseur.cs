using Data;
using Definition;
using GeneraFi.Infrastructure;
using Importation.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class BFournisseur : BusinessBase<Fournisseur>
    {
        public BFournisseur() : base(new GFournisseur())
        {
        }
    }
}
