using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
   public class Labo
    {
        public static string DoubleToString(String val)
        {
            return double.Parse(val).ToString().Replace(',', '.');
        }
        public static string afString(object valeur)
        {
            if (valeur == null)
                valeur = "";
            return (valeur.ToString()).Replace("'", "’");
        }
    }
}
