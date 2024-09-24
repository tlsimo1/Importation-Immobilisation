using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
namespace Data
{
   public class GPlanComptableEse: Repository<PlanComptableEse>
    {
        public GPlanComptableEse() : base("PlanComptableEse", "compte")
        {
        }
        public override IEnumerable<PlanComptableEse> FindAllGrid()
        {

            using (SqlConnection con = new SqlConnection(GeneraFi.Infrastructure.Outils.ConnectionString))
            {
                string query= @"SELECT  compte Compte,pc1.designation ImoLibelle, CompteAmo CompteAmo, pc2.designation AmoLibelle, 
                             CompteDot CompteDot, pc3.designation DotLibelle
                             FROM PlanComptableEse pc, PlanComptable pc1, PlanComptable pc2, 
                             PlanComptable pc3  where pc.compte = pc1.numCompte 
                             and pc.CompteAmo = pc2.numCompte and pc.CompteDot = pc3.numCompte ";
                return con.Query<PlanComptableEse>(query);
                
            }
           
        }
       
        
    }
}
