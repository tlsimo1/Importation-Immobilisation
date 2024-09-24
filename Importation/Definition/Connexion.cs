using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace DATA
{
   public class Connexion
    {
       

        public static SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
       
    
       
        
        
    }
}
