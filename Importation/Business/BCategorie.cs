using Data;
using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class BCategorie : BusinessBase<Categorie>
    {
        public BCategorie() : base(new GCategorie())
        {
        }
    }
}
