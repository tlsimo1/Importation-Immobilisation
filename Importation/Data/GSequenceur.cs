using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using Definition;
using Microsoft.ApplicationBlocks.Data;
namespace DATA
{
   public class GSequenceur
    {
       private static GSequenceur _instance;
       public static GSequenceur Instance
        {
            get
            {
                if (_instance == null) { _instance = new GSequenceur(); }
                return _instance;
            }
        }
       public Sequenceur GetSequenceur_ByID(int id)
       {
           return GetSequenceur("Select * From Sequenceur  Where IdSeq=" + id);
       }
       public Sequenceur GetSequenceur_ByDesignation(String Designation,SqlCommand cmdTrs=null)
       {
           return GetSequenceur("Select * From Sequenceur Where Designation='" + Designation + "'", cmdTrs);
       }
       public List<String> GetListeSequenceur()
       {
           List<String> LsiteSeq = null;
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = Connexion.Cn;
                   SqlCommand cmdTravaille = cmd;
                   cmdTravaille.CommandText = "Select Designation From Sequenceur Where Designation!= 'AleatoireGen'";

                   if (Connexion.Cn.State != ConnectionState.Open) Connexion.Cn.Open();
                   using (SqlDataReader read = cmdTravaille.ExecuteReader())
                   {
                       LsiteSeq = new List<string>();
                       while (read.Read())
                       {
                           LsiteSeq.Add(read.GetString(0));
                       }
                       read.Close();
                       read.Dispose();
                   }
                   cmd.Dispose();
               }
           }
           catch (Exception)
           {
               LsiteSeq = null;
           }
           finally
           {
               if (Connexion.Cn.State != ConnectionState.Closed ) Connexion.Cn.Close();
           }
           return LsiteSeq;
       }
       private Sequenceur GetSequenceur(String req, SqlCommand cmdTrs=null)
       {
           Sequenceur seq =null;
           try
           {
               using (SqlCommand cmd = new SqlCommand())
               {
                   cmd.Connection = Connexion.Cn;
                   SqlCommand cmdTravaille = cmd;
                   if (cmdTrs != null)
                       cmdTravaille = cmdTrs;
                   cmdTravaille.CommandText = req;

                   if (Connexion.Cn.State != ConnectionState.Open) Connexion.Cn.Open();
                   using (SqlDataReader read = cmdTravaille.ExecuteReader())
                   {
                       if (read.Read())
                       {
                           seq = new Sequenceur();
                           seq.IDSeq = read.GetInt32(0);
                           seq.Designation = read.GetString(1);
                           seq.Code =read.IsDBNull(2)?"":read.GetString(2);
                           seq.NumSuiv = read.GetInt32(3);
                           read.Close();
                       }
                       read.Dispose();
                   }
                   cmd.Dispose();
               }
           }
           catch (Exception)
           {
               seq = null;
           }
           finally
           {
               if (Connexion.Cn.State != ConnectionState.Closed && cmdTrs==null) Connexion.Cn.Close();
           }
           return seq;
       }

       public int Ajouter(Sequenceur seq)
       {
           string _requete = String.Format("Insert Into Sequenceur(Designation,Code,NumSuivant) values('{0}','{1}',{2})", seq.Designation, seq.Code, seq.NumSuiv);
           try
           {
               SqlHelper.ExecuteNonQuery(Connexion.Cn, CommandType.Text, _requete);
           }
           catch (SqlException ex)
           {
               if (ex.Number == 1222)
                   return -1223;
               else
                   return -1;
           }
           return 1;
       }

       public int Modifier(Sequenceur seq,String OldDes)
       {
           int reponse = 0;
           using (SqlCommand cmd = new SqlCommand())
           {
               cmd.Connection = Connexion.Cn;
               try
               {
                   if (Connexion.Cn.State != ConnectionState.Open) Connexion.Cn.Open();
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Erreur " + ex.Message);
                   return -404;
               }
               SqlTransaction transaction = Connexion.Cn.BeginTransaction(IsolationLevel.Snapshot);

               try
               {
                   cmd.Transaction = transaction;
                   string _requete = String.Format("Update Sequenceur Set Designation='{0}' , Code='{1}' , NumSuivant={2} Where IdSeq={3} and NumSuivant<={2}; ", seq.Designation, seq.Code, seq.NumSuiv, seq.IDSeq);
                   cmd.CommandText = _requete;
                   reponse = cmd.ExecuteNonQuery();
                   if (reponse > 0)
                   {
                       _requete = String.Format("Update Immobilisation Set Sequenceur='{0}' Where Sequenceur='{1}'",seq.Designation, OldDes);
                       cmd.CommandText = _requete;
                       cmd.ExecuteNonQuery();

                       _requete = String.Format("Update AffectationEnAtt Set Sequenceur='{0}' Where Sequenceur='{1}'", seq.Designation, OldDes);
                       cmd.CommandText = _requete;
                       cmd.ExecuteNonQuery();

                       _requete = String.Format("Update CodeBarre Set sequenceur='{0}' Where sequenceur='{1}'", seq.Designation, OldDes);
                       cmd.CommandText = _requete;
                       cmd.ExecuteNonQuery();
                   }
                   transaction.Commit();
                   if (reponse > 0) reponse = 2;
               }
               catch (SqlException ex)
               {
                   transaction.Rollback();
                   if (ex.Number == 1222)
                       return -1222;
                   else
                       return -1;
               }
               finally
               {
                   if (Connexion.Cn.State != ConnectionState.Closed) Connexion.Cn.Close();
               }
           }
           return reponse;
       }
       public int ExisteSequenceur_Immo(String seq)
       {
           String req = String.Format("Select Count(*) From Immobilisation Where Sequenceur='{0}'",seq);
           return ExecuteScaler(req);
       }
       public int ExisteSequenceur_Facture(String seq)
       {
           String req = String.Format(" Select COUNT(idAffEnAtt) " +
                                     " From AffectationEnAtt aff  inner join  Entree e on aff.idEntree=e.idEntree inner join Facture f on e.numFact= f.idFact " +
                                     " Where Sequenceur='{0}' and f.etatFact!='Affectée'", seq);
           return ExecuteScaler(req);
       }

       int ExecuteScaler(String Req)
       {

           int reponse = -2;
           using (SqlCommand cmd= new SqlCommand())
           {
               cmd.Connection = Connexion.Cn;
               cmd.CommandText = Req;
               try
               {
                   if (Connexion.Cn.State != ConnectionState.Open) Connexion.Cn.Open();
                   reponse =int.Parse(cmd.ExecuteScalar().ToString());
               }
               catch (Exception)
               {
                   reponse = -1;
               }
               finally
               {
                   if (Connexion.Cn.State != ConnectionState.Closed) Connexion.Cn.Close();
               }
               cmd.Dispose();
           }
           return reponse;
       }

       public String GetDecodage(Immobilisation immo,SqlCommand cmdTrs=null)
       {
           String[] Listecode = new string[] { "Ste", "CA", "Loc", "IM", "D" };
           
           string strDec = "";
           Sequenceur seq = GetSequenceur_ByDesignation(immo.Sequenceur, cmdTrs);
           String DecSC = "";
           if (seq.Code == null)
               seq.Code = "";
           String[] codeSplit = seq.Code.Split('$');
           String partCode = "", shortCode = "";
           strDec = "" + seq.IDSeq;
           int indexCr = 0, indexCrFerm = 0, indexPar = 0, indexParFerm = 0;
           int nbrCaractere = 0;
           for (int i = 0; i < codeSplit.Length; i++)
           {
               partCode = codeSplit[i];
               indexCr = partCode.IndexOf('[');
               indexCrFerm = partCode.IndexOf(']');
               indexPar = partCode.IndexOf('(');
               indexParFerm = partCode.IndexOf(')');

               if (i == 0 && codeSplit[i] != "")
               {
                   strDec += codeSplit[i].Replace("(", "").Replace(")", "");
               }
               else
               {
                   if (i > 0)
                   {
                       DecSC = "";
                       shortCode = partCode;
                       if (indexCr > 0 || indexPar > 0)
                       {
                           if (indexCr > indexPar && indexPar > -1)
                               shortCode = partCode.Substring(0, indexPar);
                           else
                               if (indexCr > -1)
                                   shortCode = partCode.Substring(0, indexCr);
                               else
                                   shortCode = partCode.Substring(0, indexPar);
                       }
                       switch (shortCode)
                       {
                           case "Ste":
                                DecSC = "generafi";
                               break;
                           case "CA": break;
                           case "Loc":
                               DecSC = immo.Localisation;
                               break;
                           case "IM":
                               DecSC = immo.NumGroupe;
                               break;
                           case "D":
                               DecSC= immo.DateAcquisition.Day + "" + immo.DateAcquisition.Month + "" + immo.DateAcquisition.Year;
                               break;
                           default:
                               break;
                       }
                       if (indexCr > -1)
                       {
                           int.TryParse(partCode.Substring(indexCr + 1, indexCrFerm - indexCr - 1), out nbrCaractere);
                           DecSC = DecSC.Length > nbrCaractere ? DecSC.Substring(0, nbrCaractere) : DecSC;
                       }
                       strDec += DecSC;
                       if (indexPar > -1)
                       {
                           strDec+=partCode.Substring(indexPar).Replace("(", "").Replace(")", "");
                       }
                   }
               }
           }
           return strDec;
       
       }
    }
}
