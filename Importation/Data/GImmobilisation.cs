using DATA;
using Definition;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importation.Data
{
    class GImmobilisation
    {
        private String _requete;
        private SqlDataReader _read;
        private SqlDataAdapter _da = new SqlDataAdapter();
        private static GImmobilisation _instance;
        public static GImmobilisation Instance
        {
            get
            {
                if (_instance == null) { _instance = new GImmobilisation(); }
                return _instance;
            }
        }

        public int Ajouter(Immobilisation immo, string user, ref string messageErreur, SqlCommand cmdTrs = null)
        {
            int idImmo = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlCommand cmdTravaille;
                SqlTransaction transaction = null;
                if (cmdTrs == null)
                {
                    if (Connexion.Cn.State != ConnectionState.Open) Connexion.Cn.Open();
                    cmd.Connection = Connexion.Cn;
                    transaction = Connexion.Cn.BeginTransaction(IsolationLevel.Snapshot);
                    cmd.Transaction = transaction;
                    cmdTravaille = cmd;
                }
                else
                    cmdTravaille = cmdTrs;

                //cmd.Connection = Connexion.Cn;
                //if (Connexion.Cn.State != ConnectionState.Open) Connexion.Cn.Open();
                //transaction = Connexion.Cn.BeginTransaction(IsolationLevel.Snapshot);
                try
                {
                    //cmd.Transaction = transaction;
                    idImmo = Ajouter_Immo(immo, cmdTravaille, user, ref messageErreur);
                    if (cmdTrs == null && idImmo > 0)
                        transaction.Commit();
                }
                catch (SqlException ex)
                {
                    idImmo = -1;
                    if (cmdTrs == null)
                        transaction.Rollback();
                }
                finally
                {
                    if (cmdTrs == null) if (Connexion.Cn.State != ConnectionState.Closed) Connexion.Cn.Close();
                }
            }
            return idImmo;
        }

        private int Ajouter_Immo(Immobilisation immo, SqlCommand cmd, String user, ref String messageErreur, String CodeBarre = "")
        {

            int idImmo = 0;
            immo.Present = immo.Localisation == string.Empty ? false : true;
            //Connexion.Transaction = Connexion.Cn.BeginTransaction();
            String StrCategorie = immo.Categorie < 1 ? "NULL" : immo.Categorie + "";

            if (immo.Localisation != null)
            {
                immo.Localisation = Labo.afString(immo.Localisation);
            }
            string caExiste = immo.CentresAnalytique == null || immo.CentresAnalytique.Count == 0 ? "false" : "true";
            immo.NumGroupePere = immo.NumGroupePere == null ? "" : immo.NumGroupePere;
            int codeErreur = VerifierExistance(immo, cmd);
            if (immo.Localisation == string.Empty || immo.Localisation == "0")
                immo.Localisation = "NULL";
            if (codeErreur < 0)
                return codeErreur;

            _requete = String.Format("INSERT INTO Immobilisation (prixAcquisition,dateMiseEnService,baseamo,type,dateAcquisition,designation," +
                                     "numGroupe,fournisseur,amortAnterieur,etatImmo,tva,amortissement,duree,localisation,ca,sysCreatedUser,present,dateAmoAnt,inventoriable" +
                                     ",numGroupePere,grouperDestination,Qte,idEntree,famille,Reference,NumFact,derogatoire,amortissementFisc,dureeFisc,amortAnterieurFisc,Sequenceur,Categorie,CatCDG,Observation,NumPO,Capex,dureeEtr,amortAnterieurEtr,dureeFiscEtr,amortAnterieurFiscEtr,idFacture,baseamoEtr,amortissementEtr,amortCumule,amortCumuleEtr,grouper,EtatDuBien,tag)" +
                                      " VALUES({0},CONVERT(datetime, '{1}',103),{2},'{3}',CONVERT(datetime, '{4}',103),'{5}','{6}','{7}',{8},'Creer',{9},'{10}',{11},'{12}'" +
                                               ",'{13}','{14}','{15}',CONVERT(datetime, '{16}',103),'{17}','{18}','{19}',{20},{21},'{22}','{23}','{24}','{25}','{26}',{27},{28},'{29}',{30},'{31}','{32}','{33}','{34}',{35},{36},{37},{38},{39},{40},'{41}','{42}',{43},'{44}','{45}','{46}');SELECT SCOPE_IDENTITY();"

                                      , immo.PrixAcquisition.ToString().Replace(',', '.'),Convert.ToDateTime(immo.DateMiseEnService), immo.BaseAmortissable.ToString().Replace(',', '.'), immo.Type,

                                      Convert.ToDateTime(immo.DateAcquisition), Labo.afString(immo.Designation), immo.NumGroupe, Labo.afString(immo.NomFournisseur), immo.AmortAnterieur.ToString().Replace(',', '.'),

                                      Labo.DoubleToString("" + immo.Tva), immo.ModeAmortissement, immo.DureeAmortissement.ToString().Replace(',', '.'), immo.Localisation,

                                      caExiste, user, immo.Present, immo.DateAmoAnt.Date.ToShortDateString(), immo.Inventoriable, immo.NumGroupePere, immo.SourceNumGroupe, immo.Qte,

                                      immo.IdEntree, immo.Famille, Labo.afString(immo.Reference),
                                      Labo.afString(immo.NumFact), immo.Derogatoire, immo.ModeAmortissementFisc,

                                      immo.DureeAmortissementFisc.ToString().Replace(',', '.'), immo.AmortAnterieurFisc.ToString().Replace(',', '.'), immo.Sequenceur, StrCategorie, Labo.afString(immo.CatCDG), Labo.afString(immo.Obs), Labo.afString(immo.NumPO), Labo.afString(immo.CAPEX), immo.DureeUSGAAP.ToString().Replace(',', '.'), immo.AmoAntrUSGAAP.ToString().Replace(',', '.'),

                                      immo.DureeAmortissementFiscEtr.ToString().Replace(',', '.'), immo.AmortAnterieurFiscEtr.ToString().Replace(',', '.'), immo.IdFacture, immo.BaseAmortissableEtr.ToString().Replace(',', '.'), immo.ModeAmortissementEtr, Labo.DoubleToString("" + immo.AmortCumul), Labo.DoubleToString("" + immo.AmortCumulEtr), immo.Grouper, Labo.afString(immo.EtatDuBien), Labo.afString(immo.Tag));

            cmd.CommandText = _requete;
            //cmd.ExecuteNonQuery();
            //_requete = String.Format("Select Max(idImmo) From Immobilisation");
            //cmd.CommandText = _requete;
            try
            {
                idImmo = int.Parse(cmd.ExecuteScalar().ToString());


                immo.NumGroupe = "IM" + idImmo;
                //////Affecter le compte
                cmd.CommandText = String.Format("INSERT INTO AffPlanComptable(compte,idImmo,dateAff) Values('{0}',{1},CONVERT(datetime, '{2}',103))",
                   immo.Compte, idImmo, immo.DateAcquisition.Date.ToShortDateString());
                cmd.ExecuteNonQuery();
                //Affecter Le mode d'amortissement
                cmd.CommandText = String.Format("INSERT INTO ModeAmortissement(IdImmo,modAmo,dureeAmo,dateAff)" +
                                         " Values({0},'{1}',{2},CONVERT(datetime, '{3}',103))", idImmo, immo.ModeAmortissement,
                                         immo.DureeAmortissement.ToString().Replace(',', '.'), immo.DateAcquisition.Date.ToShortDateString());
                cmd.ExecuteNonQuery();

                //Affecter la localisation
                if (immo.Localisation != null && immo.Localisation != string.Empty && immo.Localisation != "NULL")
                {
                    cmd.CommandText = String.Format("INSERT INTO AffLocalisation(idImmo,localisation,dateAff)" +
                                            " Values({0},{1},CONVERT(datetime, '{2}',103))", idImmo, immo.Localisation,
                                           immo.DateAcquisition.Date.ToShortDateString());
                    cmd.ExecuteNonQuery();
                }
                //Affecter le centre Analytique
                for (int i = 0; immo.CentresAnalytique != null && i < immo.CentresAnalytique.Count; i++)
                {
                    cmd.CommandText = String.Format("INSERT INTO AffCentreAnaly(idImmo,centreAnaly,taux,dateAff,cleOrder) Values({0},'{1}',{2},CONVERT(datetime, '{3}',103),1)",
                                             idImmo, immo.CentresAnalytique[i].CentreAnaly, immo.CentresAnalytique[i].Taux, immo.DateAcquisition.Date.ToShortDateString());
                    cmd.ExecuteNonQuery();
                }
                if (immo.AmortAnterieur > 0)
                {
                    cmd.CommandText = string.Format("INSERT INTO Amortissement(idImmo,dateAmo,valeurAmo) Values({0},CONVERT(datetime, '{1}',103),{2})", idImmo, DateTime.Now, Labo.DoubleToString("" + immo.AmortAnterieur));
                    cmd.ExecuteNonQuery();
                }
                //Ajout Code Barre

                int QteCB = immo.Qte;
                if (!immo.Inventoriable)
                    QteCB = 1;
                if (immo.ListCodeBarre != null)
                {
                    for (int i = 0; i < immo.ListCodeBarre.Count; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(immo.ListCodeBarre[i].Code))
                        {
                            //cmd.CommandText = String.Format("Select Designation From Sequenceur Where SUBSTRING(CONVERT(nvarchar(10),IdSeq),1,1)='{0}' and Designation!='AleatoireGen'", immo.ListCodeBarre[i].Code[0]);
                            //object objStr = cmd.ExecuteScalar();
                            //if (objStr == null)
                            //{
                            cmd.CommandText = string.Format("Insert Into CodeBarre(idImmo,Code,sequenceur,localisation,present,NumSerie) Values({0},'{1}','{2}','{3}',0,'{4}') ", idImmo, immo.ListCodeBarre[i].Code, "", immo.Localisation, immo.ListCodeBarre[i].NumSerie);
                            int qteInsert = 0;
                            messageErreur = String.Format("Le Code Barre [{0}] affecté à une autre immobilisation.", immo.ListCodeBarre[i].Code);
                            qteInsert = cmd.ExecuteNonQuery();
                            if (qteInsert == 0)
                            {
                                return -10;
                            }
                            messageErreur = "";
                            //}
                            //else
                            //{
                            //    messageErreur = String.Format("Le Code Barre [{0}] appartient à un autre squenceur .", immo.ListCodeBarre[i].Code);
                            //    return -10;
                            //}
                        }
                        else
                        {
                            string codeSeq = codeSeq = GSequenceur.Instance.GetDecodage(immo, cmd);
                            cmd.CommandText = string.Format("Insert Into CodeBarre(idImmo,Code,sequenceur,localisation,present,NumSerie) Values({0},'{1}','{2}','{3}',0,'{4}') ", idImmo, codeSeq, immo.Sequenceur, immo.Localisation, immo.ListCodeBarre[i].NumSerie);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    QteCB = immo.Qte - immo.ListCodeBarre.Count;
                    if (QteCB > 1 && !immo.Inventoriable)
                        QteCB = 1;
                }
                if (QteCB > 0)
                {
                    string codeSeq = codeSeq = GSequenceur.Instance.GetDecodage(immo, cmd);
                    for (int i = 0; i < QteCB; i++)
                    {
                        cmd.CommandText = string.Format("Insert Into CodeBarre(idImmo,Code,sequenceur,localisation,present) Values({0},'{1}','{2}','{3}',0) ", idImmo, codeSeq, immo.Sequenceur, immo.Localisation);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (!String.IsNullOrWhiteSpace(CodeBarre))
                {
                    cmd.CommandText = string.Format("update CodeBarreInv Set code={0},present=1,change=1,sequenceur='' Where idImmo={1} and isIMC=0 ", CodeBarre, idImmo);
                    cmd.ExecuteNonQuery();
                }
                AjoutHistorique("Création", idImmo, cmd);
            }
            catch (Exception ex)
            {
                if (String.IsNullOrWhiteSpace(messageErreur))
                {
                    messageErreur = ex.Message;
                    return -404;
                }
            }
            return idImmo;
        }
        public static int AjoutHistorique(String operation, int idImmo, SqlCommand cmd = null)
        {
            string requete = String.Format("INSERT INTO Historique(dateHistorique,libelleHistorique,idImmo) Values(CONVERT(datetime, '{0}',103),'{1}',{2})",
                DateTime.Now, Labo.afString(operation), idImmo);
            int QteLigneAff = 0;
            if (cmd == null)
                QteLigneAff = SqlHelper.ExecuteNonQuery(Connexion.Cn, CommandType.Text, requete);
            else
            {
                cmd.CommandText = requete;
                try
                {
                    QteLigneAff = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    QteLigneAff = 0;
                }
            }
            return QteLigneAff;
        }
        private int VerifierExistance(Immobilisation immo, SqlCommand cmd, bool blnNonAmort = false)
        {
            int nbr = 0;
            if (immo.Localisation != string.Empty && immo.Localisation != "NULL" && immo.Localisation != "0")
            {

                cmd.CommandText = String.Format("Select count(localisation) from Localisation with(HOLDLOCK) where localisation='{0}'", immo.Localisation);
                nbr = int.Parse(cmd.ExecuteScalar().ToString());
                if (nbr == 0)
                {
                    //cmd.Transaction.Rollback();
                    return -2;
                }
            }
            if (!blnNonAmort)
            {
                cmd.CommandText = String.Format("Select count(compte) from PlanComptableEse with(HOLDLOCK) where compte='{0}'", immo.Compte);
                nbr = int.Parse(cmd.ExecuteScalar().ToString());
                //if (nbr == 0)
                //{
                //    //cmd.Transaction.Rollback();
                //    return -3;
                //}
            }
            if (immo.CentresAnalytique != null && immo.CentresAnalytique.Count > 0)
            {
                string concatCA = "'" + immo.CentresAnalytique[0].CentreAnaly + "'";
                for (int i = 1; i < immo.CentresAnalytique.Count; i++)
                {
                    concatCA += ",'" + immo.CentresAnalytique[i].CentreAnaly + "'";
                }
                cmd.CommandText = String.Format("select COUNT(*) from CentreAnalytique with(HOLDLOCK) where centreAnaly in({0})", concatCA);
                nbr = int.Parse(cmd.ExecuteScalar().ToString());
                //if (nbr != immo.CentresAnalytique.Count)
                //{
                //    //cmd.Transaction.Rollback();
                //    return -4;
                //}
            }
            if (immo.Famille != null && immo.Famille != string.Empty)
            {
                //cmd.CommandText = String.Format("Select count(nomFamille) from Famille with(HOLDLOCK) where nomFamille='{0}'", immo.Famille);
                //nbr = int.Parse(cmd.ExecuteScalar().ToString());
                //if (nbr == 0)
                //{
                //    cmd.Transaction.Rollback();
                //    return -5;
                //}
            }
            if (immo.Sequenceur != null && !String.IsNullOrWhiteSpace(immo.Sequenceur))
            {
                cmd.CommandText = String.Format("Select count(Designation) from Sequenceur with(HOLDLOCK) where Designation='{0}'", immo.Sequenceur);
                nbr = int.Parse(cmd.ExecuteScalar().ToString());
                if (nbr == 0)
                {
                    //cmd.Transaction.Rollback();
                    return -6;
                }
            }
            return 0;
        }
    }
}
