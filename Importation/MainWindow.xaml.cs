using Business;
using Definition;
using Importation.Data;
using Importation.View;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Importation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dtImportExcel;
        BusImmobilisation busImmo = new BusImmobilisation();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            GeneraFi.Infrastructure.Outils.ConnectionString = @"Data Source=MONPC-PC\SQLSERVER2014;Initial Catalog=BDVide;Integrated Security=True";
        }
        public DataTable ImportExcel2007(String strFilePath, String SheetName)
        {
            if (!File.Exists(strFilePath)) return null;
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
            + "Data Source=" + strFilePath + ";"
            + "Extended Properties='Excel 8.0;HDR=No;IMEX=0'";

            OleDbConnection connExcel = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            try
            {
                cmdExcel.Connection = connExcel;
                //Check if the Sheet Exists
                connExcel.Open();
                DataTable dtExcelSchema;
                //Get the Schema of the WorkBook
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                connExcel.Close();
                //Read Data from Sheet1
                connExcel.Open();
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                da.SelectCommand = cmdExcel;
                da.Fill(ds, SheetName);
                connExcel.Close();
                return ds.Tables[SheetName];
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cmdExcel.Dispose();
                connExcel.Dispose();
            }
        }

        public DataTable GetFeuille(String strFilePath)
        {
            if (!File.Exists(strFilePath)) return null;
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
            + "Data Source=" + strFilePath + ";"
            + "Extended Properties='Excel 8.0;HDR=No;IMEX=0'";

            OleDbConnection connExcel = new OleDbConnection(strExcelConn);
            OleDbCommand cmdExcel = new OleDbCommand();
            try
            {
                cmdExcel.Connection = connExcel;
                //Check if the Sheet Exists
                connExcel.Open();
                DataTable dtExcelSchema;
                //Get the Schema of the WorkBook
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                return dtExcelSchema;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cmdExcel.Dispose();
                connExcel.Dispose();
            }
        }

        private void Openfile_Click(object sender, RoutedEventArgs e)
        {
            dgImporter.Visibility = Visibility.Visible;
            List<string> list1 = new List<string>();
            try
            {
                string sht = string.Empty;
                OpenFileDialog openFileDlg = new OpenFileDialog();
                Nullable<bool> result = openFileDlg.ShowDialog();
                openFileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (result == true)
                {

                    // FileNameTextBox.Text = openFileDlg.FileName;
                    // txtfile.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                    txtfile.Text = openFileDlg.FileName;
                }
                string filename = txtfile.Text;
                OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties='Excel 12.0 xml;HDR=YES;'");
                connection.Open();
                DataTable Sheets = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow dr in Sheets.Rows)
                {
                    sht = dr[2].ToString().Replace("'", "");

                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from [" + sht + "]", connection);
                }
                dtImportExcel = ImportExcel2007(filename, sht);
                dgImporter.ItemsSource = dtImportExcel.AsDataView();

               
                //test.dt = dtImportExcel;
                var listCombo = GetVisualChildCollection<DataGrid>(this).Select(x => x.Columns);
            }
            catch (Exception)
            {
                return;
            }
        }
        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            List<ComboItems> listCombo = new List<ComboItems>();
            listCombo.Add(new ComboItems() { id = 1, nom = "Désignation", type = "string" });
            listCombo.Add(new ComboItems() { id = 2, nom = "Code Fournisseur", type = "string" });
            listCombo.Add(new ComboItems() { id = 3, nom = "Qte", type = "int" });
            listCombo.Add(new ComboItems() { id = 4, nom = "Inventairesociele", type = "string" });
            listCombo.Add(new ComboItems() { id = 5, nom = "N° Facture", type = "string" });
            listCombo.Add(new ComboItems() { id = 6, nom = "N° BC", type = "int" });
            listCombo.Add(new ComboItems() { id = 7, nom = "Modele", type = "string" });
            listCombo.Add(new ComboItems() { id = 8, nom = "Marque", type = "string" });
            listCombo.Add(new ComboItems() { id = 9, nom = "Observation", type = "string" });
            listCombo.Add(new ComboItems() { id = 10, nom = "Référence", type = "string" });

            listCombo.Add(new ComboItems() { id = 11, nom = "Date d'acquisition", type = "date" });
            listCombo.Add(new ComboItems() { id = 12, nom = "date mise en service", type = "date" });
            listCombo.Add(new ComboItems() { id = 13, nom = "code Categorie", type = "string" });

            listCombo.Add(new ComboItems() { id = 14, nom = "prix  d'acquisition", type = "double" });

            listCombo.Add(new ComboItems() { id = 16, nom = "Compte d'immobilisation", type = "string" });

            listCombo.Add(new ComboItems() { id = 17, nom = "Mode d'amortissement", type = "string" });
            listCombo.Add(new ComboItems() { id = 18, nom = "duree d'amortissement", type = "int" });
            listCombo.Add(new ComboItems() { id = 19, nom = "base amortissable", type = "string" });
            listCombo.Add(new ComboItems() { id = 20, nom = "Amortissement  Ant ", type = "string" });
            listCombo.Add(new ComboItems() { id = 21, nom = "code localisation", type = "string" });


            if (!string.IsNullOrWhiteSpace(txtfile.Text))
            {
                int index = 0;
                bool isMatch = true;
                bool isValid = true;
                DataTable dtImporte = new DataTable(); ;
                List<ComboItems> champsObligatoire = new List<ComboItems>();
                champsObligatoire.Add(new ComboItems() { id = 1, nom = "Désignation", type = "string" });
                champsObligatoire.Add(new ComboItems() { id = 2, nom = "N° Facture", type = "string" });
                champsObligatoire.Add(new ComboItems() { id = 3, nom = "Date d'acquisition", type = "date" });
                champsObligatoire.Add(new ComboItems() { id = 4, nom = "prix  d'acquisition", type = "double" });
                champsObligatoire.Add(new ComboItems() { id = 4, nom = "Qte", type = "int" });
                champsObligatoire.Add(new ComboItems() { id = 4, nom = "Compte d'immobilisation", type = "int" });

      


                List<string> list = GetVisualChildCollection<ComboBox>(this).Select(x => x.Text).ToList();
                var query = list.GroupBy(x => x)
                           .Where(g => g.Count() > 1 && !g.Contains(""))
                           .Select(y => y.Key)
                           .ToList();

                list.RemoveAt(0);
                var verifierChampObligatoire = champsObligatoire.Select(x => x.nom).Except(list).ToList();
                if(query.Count==0)
                {
                    
                    if (verifierChampObligatoire.Count == 0)
                    {
                        int i = 0;
                        dtImporte = ((DataView)dgImporter.ItemsSource).ToTable();
                        foreach (DataColumn col in dtImporte.Columns)
                        {
                            if (dtImporte.Columns.Contains(list[i]))
                            {
                                dtImporte.Columns[list[i]].ColumnName = i.ToString();
                            }
                            if (!string.IsNullOrEmpty(list[i]))
                                col.ColumnName = list[i];
                            i++;
                        }
                        foreach (var item in list)
                        {
                            string itemselected = listCombo.Where(x => x.nom == item).Select(x => x.type).FirstOrDefault();


                            if (itemselected == "string")
                            {
                                foreach (DataRowView dr in dtImporte.DefaultView)
                                {
                                    isValid = Is(dr[index].ToString(), typeof(string));
                                    if (!isValid)
                                    {
                                        isMatch = false;
                                        break;
                                    }
                                }
                            }
                            else if (itemselected == "int")
                            {
                                foreach (DataRowView dr in dtImporte.DefaultView)
                                {
                                    isValid = Is(dr[index].ToString(), typeof(int));
                                    string test = dr[index].ToString();
                                    if (!isValid && !string.IsNullOrEmpty(dr[index].ToString()))
                                    {
                                        isMatch = false;
                                        break;
                                    }
                                }
                            }
                            else if (itemselected == "double")
                            {
                                foreach (DataRowView dr in dtImporte.DefaultView)
                                {
                                    isValid = Is(dr[index].ToString(), typeof(double));
                                    if (!isValid && !string.IsNullOrEmpty(dr[index].ToString()))
                                    {
                                        isMatch = false;
                                        break;
                                    }
                                }
                            }
                            else if (itemselected == "date")
                            {
                                foreach (DataRowView dr in dtImporte.DefaultView)
                                {
                                    isValid = Is(dr[index].ToString(), typeof(DateTime));
                                    if (!isValid && !string.IsNullOrEmpty(dr[index].ToString()))
                                    {
                                        isMatch = false;
                                        break;
                                    }
                                }
                            }
                            else if (itemselected == "bool")
                            {
                                foreach (DataRowView dr in dtImporte.DefaultView)
                                {
                                    isValid = Is(dr[index].ToString(), typeof(bool));
                                    if (!isValid)
                                    {
                                        isMatch = false;
                                        break;
                                    }
                                }
                            }
                            index++;
                            if (!isMatch)
                            {
                                UCGeneraFi.GeneraFiMessageBox.Show("Type de donnés invalide");
                                isMatch = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        UCGeneraFi.GeneraFiMessageBox.Show("Veuillez séléctionner tous les champs obligatoires");
                        isValid = false;
                    }
                }
                else
                {
                    UCGeneraFi.GeneraFiMessageBox.Show("Veuillez ne pas sélectionner des élements similaires");
                    isMatch = false;
                    
                }
                
                if (isMatch && isValid)
                {
                    DateTime? nullDateTime = null;
                    try
                    {
                        foreach (DataRow row in dtImporte.Rows)
                        {
                          
                            string des = dtImporte.Columns.Contains("Désignation") ? row["Désignation"].ToString():"";
                            string numFact = dtImporte.Columns.Contains("N° Facture") ? row["N° Facture"].ToString() : "";
                            string numBC =dtImporte.Columns.Contains("N° BC")?row["N° BC"].ToString():"";
                            string libleFact = dtImporte.Columns.Contains("Libelé de facture") ? row["Libelé de facture"].ToString() : "";
                            string codeFrs = dtImporte.Columns.Contains("Code Fournisseur") ? row["Code Fournisseur"].ToString() : "";
                            string reference = dtImporte.Columns.Contains("Référence") ? row["Référence"].ToString().Replace("","_") : "";
                            string marque = dtImporte.Columns.Contains("Marque") ? row["Marque"].ToString() : "";
                            string model = dtImporte.Columns.Contains("Modele") ? row["Modele"].ToString() : "";
                            string etatdubien = dtImporte.Columns.Contains("Etat du Bien") ? row["Etat du Bien"].ToString() : "";
                            string observation = dtImporte.Columns.Contains("observation") ? row["observation"].ToString() : "";
                            DateTime dateAcqui = dtImporte.Columns.Contains("Date d'acquisition") ? Convert.ToDateTime(row["Date d'acquisition"].ToString()):Convert.ToDateTime(nullDateTime);
                            DateTime dateMiseEnService = dtImporte.Columns.Contains("date mise en service") ? Convert.ToDateTime(row["date mise en service"].ToString()): Convert.ToDateTime(nullDateTime);
                            string prixAcqui = dtImporte.Columns.Contains("prix  d'acquisition") ? row["prix  d'acquisition"].ToString() : "";
                            string baseAmo = dtImporte.Columns.Contains("base amortissable") ? row["base amortissable"].ToString() : "";
                            string Qte = dtImporte.Columns.Contains("Qte") ? row["Qte"].ToString() : "";
                            string codeFamille = dtImporte.Columns.Contains("code Famille") ? row["code Famille"].ToString() : "";
                            string codeCat = dtImporte.Columns.Contains("code Categorie") ? row["code Categorie"].ToString() : "";
                            string codeLoc = dtImporte.Columns.Contains("code localisation") ? row["code localisation"].ToString() : "";
                            string codeCenteAnaly = dtImporte.Columns.Contains("code du centre analytique") ? row["code du centre analytique"].ToString() : "";
                            string comteImmo = dtImporte.Columns.Contains("Compte d'immobilisation") ? row["Compte d'immobilisation"].ToString() : "";
                            string dureeAmo = dtImporte.Columns.Contains("duree d'amortissement") ? row["duree d'amortissement"].ToString() : "";
                            string modeAmo = dtImporte.Columns.Contains("Mode d'amortissement") ? row["Mode d'amortissement"].ToString() : "";
                            string amoAnt = dtImporte.Columns.Contains("Amortissement  Ant au 31/12/2017") ? row["Amortissement  Ant au 31/12/2017"].ToString() : "";
                            string Inventoriable = dtImporte.Columns.Contains("Inventoriable (0/1)") ? row["Inventoriable (0/1)"].ToString() : "";
                            string codeBarre = dtImporte.Columns.Contains("Code Barre (separés par ; si plusieurs)") ? row["Code Barre (separés par ; si plusieurs)"].ToString() : "";
                            if (Inventoriable == "0")
                            {
                                Inventoriable = "false";
                            }
                            else
                            {
                                Inventoriable = "true";
                            }
                            AjouterImmo(modeAmo, Qte, des, dateAcqui, dateMiseEnService, "12", baseAmo, "23400090", codeLoc, codeFrs, Convert.ToBoolean(Inventoriable), codeFamille, reference,
                            "2", "16", "4", amoAnt, numFact, "54", observation, "5", "98", "45", "8", etatdubien, codeBarre, null);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        UCGeneraFi.GeneraFiMessageBox.Show("Importation éfectuée avec sucées");
                    }
                    
                    
                }
                else
                    return;
            }

          
        }
        private int AjouterImmo(String ModeAmo, String SQte, String Des, DateTime DAcqui, DateTime DMService, String MontantAcq,
              String BaseAmort, String compte, String Loc, String Frs, bool Inv, String Famille, String Ref, string strduree, string cat,
              String strCA, String AmoAntrFisc, String Fact, String CatCDG, String obs, String NumPO, String CAPEX, String AmoAntrUSGAB,
              string strdureeUSGAB, string etatDuBien, string codeBarre, System.Data.SqlClient.SqlCommand cmd = null)
        {
            int qte=0;
            float duree = float.Parse(strduree);
            if(SQte!="")
            {
                 qte = int.Parse(SQte);
            }
            Immobilisation imm = new Immobilisation();
            imm.Designation = Des;
            imm.DateMiseEnService = DAcqui;
            imm.DateAcquisition = DMService;
            imm.Type = "";
            imm.PrixAcquisition = double.Parse(MontantAcq) / qte;
            if(BaseAmort!="")
            imm.BaseAmortissable = double.Parse(BaseAmort) / qte;

            imm.NumGroupe = "";
            imm.Compte = compte;
            imm.ModeAmortissement = ModeAmo;
            imm.DureeAmortissement = (float)duree;
            imm.Localisation = Loc;
            imm.NomFournisseur = Frs;
            imm.Inventoriable = Inv;
            imm.Famille = Famille;
            imm.Reference = Ref;
            imm.Categorie = int.Parse(cat);
            imm.NumFact = Fact;
            imm.CatCDG = CatCDG;
            imm.Obs = obs;
            imm.CAPEX = CAPEX;
            imm.NumPO = NumPO;
            imm.EtatDuBien = etatDuBien;
            imm.ListCodeBarre = new List<CodeBarre>();
            imm.ListCodeBarre.Add(new CodeBarre() { Code = codeBarre });
            if (AmoAntrFisc != "")
            {
                imm.AmortAnterieur = double.Parse(AmoAntrFisc) / qte;
                imm.DateAmoAnt = Convert.ToDateTime(DateAmo.Text);
            }
            else
            {
                imm.AmortAnterieur = 0;
                imm.DateAmoAnt = new DateTime(1900, 1, 1);
            }
            imm.Tva = (imm.BaseAmortissable * 0.2) / qte;
            List<AffCentreAnaly> listeCA = new List<AffCentreAnaly>();
            AffCentreAnaly CA;
            if (!String.IsNullOrWhiteSpace(strCA))
            {
                CA = new AffCentreAnaly();
                CA.CentreAnaly = strCA;
                CA.Taux = 100;
                listeCA.Add(CA);
            }
            imm.Derogatoire = false;
            imm.CentresAnalytique = listeCA;
            imm.Sequenceur = "GeneraFi";
            imm.DureeUSGAAP = float.Parse(strdureeUSGAB);
            imm.AmoAntrUSGAAP = float.Parse(AmoAntrUSGAB);
            if (imm.AmoAntrUSGAAP != 0)
            {
                imm.AmoAntrUSGAAP = imm.AmoAntrUSGAAP / qte;
            }
            int idImmo = 10;
            imm.Qte = qte;
            String messageErreur = "";
            idImmo = busImmo.Ajouter_Immo(imm, "Admin", ref messageErreur, cmd);
            return idImmo;
        }

        private DataGridColumnHeader GetColumnHeaderFromColumn(DataGridColumn column)
        {
            List<DataGridColumnHeader> columnheaders = GetVisualChildCollection<DataGridColumnHeader>(dgImporter);
            foreach (DataGridColumnHeader columnheader in columnheaders)
            {
                if (columnheader.Column == column)
                {
                    return columnheader;
                }
            }
            return null;
        }
        public List<T> GetVisualChildCollection<T>(object parent) where T : Visual
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection(parent as DependencyObject, visualCollection);
            return visualCollection;
        }
        private void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : Visual
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }
        public static bool Is(string input, Type targetType)
        {
            try
            {
                TypeDescriptor.GetConverter(targetType).ConvertFromString(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void Importation_Fournissuer_Click(object sender, RoutedEventArgs e)
        {
            FournisseurView v = new FournisseurView();
            v.Show();
        }

        private void Importation_centreAnalytique_Click(object sender, RoutedEventArgs e)
        {
            CentreAnalytiqueView c = new CentreAnalytiqueView();
            c.Show();
        }

        private void LocNiveau1_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name.ToString())
            {
                case "Localisation":
                    LocalisationView loc1 = new LocalisationView();
                    loc1.Show();
                    break;
                //case "locNiveau2":
                //    LocalisationView loc2 = new LocalisationView(2);
                //    loc2.Show();
                //    break;
                //case "locNiveau3":
                //    LocalisationView loc3 = new LocalisationView(3);
                //    loc3.Show();
                //    break;
                case "categorie":
                    CategorieView cat = new CategorieView();
                    cat.Show();
                    break;
                case "PlanComptableEse":
                    PlanComptableEseView pl = new PlanComptableEseView();
                    pl.Show();
                    break;
                case "PlanComptable":
                    PlanComptableView plEse = new PlanComptableView();
                    plEse.Show();
                    break;
            }
        }
    }
}
