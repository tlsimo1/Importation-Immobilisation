using Definition;
using GeneraFi.Infrastructure;
using Importation.Definition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace Data
{
    public class GFournisseur : Repository<Fournisseur>
    {
        public GFournisseur() : base("Fournisseur", "codeFrs")
        {
        }
    }
}
