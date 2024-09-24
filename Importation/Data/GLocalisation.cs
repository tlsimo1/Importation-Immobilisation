using Dapper;
using Data;
using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace Data
{
	public class GLocalisation : Repository<Localisations>
	{
		public GLocalisation() : base("Localisation", "Id_Loc")
		{
		}
		public override IEnumerable<Localisations> FindGrid(string condition)
		{
			int niveau;
			switch (condition.Replace(" ","").ToLower())
			{
				case "niveauloc=1":
					niveau = 1;
					break;
				case "niveauloc=2":
					niveau = 2;
					break;
				default:
					niveau = 3;
					break;
			}
			using (SqlConnection con = new SqlConnection(Outils.ConnectionString))
			{
				string query = string.Format(@"select * from Localisation  where  NiveauLoc = {0} and Id_Loc not in (22,23,512) ", niveau);
				return con.Query<Localisations>(query);
			}
		}

        public int GetIdSuperieure()
        {
           
            using (SqlConnection con = new SqlConnection(Outils.ConnectionString))
            {
                string query = string.Format(@"select Id_Loc from Localisation  where  NiveauLoc = {0} and localisation='Toutes' ", 0);
                var idLoc = con.QuerySingle<int>(query);
                return idLoc;
            }
        }

        public void Ajouter_Localisation(string localisation, string designation,int niveauLocalisation,int id_LocSup)
        {
            using (SqlConnection con = new SqlConnection(Outils.ConnectionString))
            {
                

                var affectedRows = con.Execute(@"INSERT INTO Localisation (localisation,designation,NiveauLoc,Id_Loc_Supp,remarque ,isInv,Resp,dateInv)
                                                VALUES(@localisation, @designation,@NiveauLoc,@Id_Loc_Supp,@remarque,@isInv,@Resp,@dateInv)",
                new { localisation = localisation,
                    designation = designation,
                    NiveauLoc = niveauLocalisation,
                    Id_Loc_Supp = id_LocSup,
                    remarque = "",
                    isInv=false,
                    Resp="",
                    dateInv=""
                });
            
            }
        }

	}
}
	

