using Business;
using Data;
using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Business
{
    public class BLocalisation : BusinessBase<Localisations>
    {
        GLocalisation gLocalisation = new GLocalisation();
        public BLocalisation() : base(new GLocalisation())
        {
        }
        public int GetIdSuperieure()
        {
            return gLocalisation.GetIdSuperieure();
        }
        public void Ajouter_Localisation(string localisation, string designation, int niveauLocalisation, int id_LocSup)
        {
             gLocalisation.Ajouter_Localisation( localisation,  designation,  niveauLocalisation,  id_LocSup);
        }
    }
}
