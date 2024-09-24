using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using Definition;
using System.ComponentModel;
using Importation.Data;

namespace Business
{
    public class BusImmobilisation
    {
        public int Ajouter_Immo(Immobilisation immo, string user,ref String messageErreur,System.Data.SqlClient.SqlCommand cmd= null)
        {
            return GImmobilisation.Instance.Ajouter(immo, user, ref messageErreur, cmd);
        }
       
    }
}
