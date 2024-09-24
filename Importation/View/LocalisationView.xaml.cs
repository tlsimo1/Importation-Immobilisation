using Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Importation.View
{
    /// <summary>
    /// Logique d'interaction pour LocalisationView.xaml
    /// </summary>
    public partial class LocalisationView : Window
    {
        DataTable dtImportExcel;
        BLocalisation _bLocalisation = new BLocalisation();
        List<string> listNiveau1 = new List<string>();
        List<string> listNiveau2 = new List<string>();
        List<string> listNiveau3 = new List<string>();
        public LocalisationView()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            //Tuple<string, string> tuple = new Tuple<string, string>();
            var list = new List<Tuple<string, string>>();
            int index = 1;
            int idLoc = 0;
            int niveauLoc = 1;
            DataTable dtImporte = new DataTable();
            dtImporte = ((DataView)dgImporter.ItemsSource).ToTable();
            List<list2> listNiv2 = new List<list2>();

            foreach (DataColumn col in dtImporte.Columns)
            {

                List<string> ListNiv1 = new List<string>(dtImporte.Rows.Count);
                if (niveauLoc == 1)
                {
                    idLoc = _bLocalisation.GetIdSuperieure();
                }
                string name = col.ColumnName;
                foreach (DataRow row in dtImporte.Rows)
                {
                    if (!string.IsNullOrEmpty(row[name].ToString()))
                    {
                        ListNiv1.Add((string)row[name]);
                    }
                }
                // List<Object> allS = (from x in listNiv2 select (Object)x).ToList();




                foreach (string item in ListNiv1)
                {
                    if (index == 1)
                    {
                        listNiveau1.Add(item);
                        listNiv2.Add(new list2() { niv1 = item, niv2 = "" });
                    }
                    else if (index == 2)
                    {
                        listNiveau2.Add(item);
                    }

                    else
                        listNiveau3.Add(item);
                }

                if (listNiveau2.Count != 0)
                {
                    List<list2> listloc2 = new List<list2>();
                    foreach (var item in listNiveau2)
                    {
                        var tempField = listNiv2.FirstOrDefault(x => x.niv2.Equals(""));
                        tempField.niv2 = item;
                        listloc2.Add(new list2() { niv1 = tempField.niv1, niv2 = tempField.niv2 });
                    }
                    var ans = (from x in listloc2
                               select new
                               {
                                   niv1 = x.niv1,
                                   niv2 = x.niv2
                               }).Distinct().ToList();
                   
                }



                if (index == 2)
                {

                    // allS.AddRange((from x in listNiv2 select (Object)x).ToList());
                }



                index++;


                //var unique_items = new HashSet<string>(ListNiv1);
                //foreach (string itemn in unique_items)
                //{
                //    string localisation = itemn;
                //    string designation = itemn.Replace(" ", "_");
                //    int niveauLocalisation = niveauLoc;
                //    int id_LocSup = idLoc;
                //    _bLocalisation.Ajouter_Localisation(localisation, designation, niveauLocalisation, id_LocSup);
                //}
                niveauLoc++;
                //var newList = unique_items.Select(s => s.Replace(" ", "_")).ToList();
            }

            #region
            //foreach (DataRowView dr in dtImporte.DefaultView)
            //{
            //  string s=  dr[index].ToString();

            //}
            //index++;
            #endregion

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


    }
    public class list2
    {
        public string niv1 { get; set; }
        public string niv2 { get; set; }
        public list2() { }
    }
}
