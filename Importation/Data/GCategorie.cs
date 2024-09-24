using Dapper;
using Definition;
using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data
{
	public class GCategorie : Repository<Categorie>
	{
		public GCategorie() : base("Categorie", "idCategorie")
		{
		}
	}
}
