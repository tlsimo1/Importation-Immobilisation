
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Importation
{
    /// <summary>
    /// Interaction logic for ImportationHeader.xaml
    /// </summary>
    public partial class ImportationHeader : UserControl
    {
        List<ComboItems> ChampsObligatoire = new List<ComboItems>();
        List<string> selectedItems = new List<string>();
        public ImportationHeader()
        {
            InitializeComponent();
            List<ComboItems> list = new List<ComboItems>();
            list.Add(new ComboItems() { id = 1, nom = "Désignation", type = "string" });
            list.Add(new ComboItems() { id = 2, nom = "Code Fournisseur", type = "string" });
            list.Add(new ComboItems() { id = 3, nom = "Qte", type = "int" });
            list.Add(new ComboItems() { id = 4, nom = "Inventairesociele", type = "string" });
            list.Add(new ComboItems() { id = 5, nom = "N° Facture", type = "int" });
            list.Add(new ComboItems() { id = 6, nom = "N° BC", type = "int" });
            list.Add(new ComboItems() { id = 7, nom = "Modele", type = "string" });
            list.Add(new ComboItems() { id = 8, nom = "Marque", type = "string" });
            list.Add(new ComboItems() { id = 9, nom = "Observation", type = "string" });
            list.Add(new ComboItems() { id = 10, nom = "Référence", type = "string" });

            list.Add(new ComboItems() { id = 11, nom = "Date d'acquisition", type = "date" });
            list.Add(new ComboItems() { id = 12, nom = "date mise en service", type = "date" });
            list.Add(new ComboItems() { id = 13, nom = "code Categorie", type = "string" });

            list.Add(new ComboItems() { id = 14, nom = "prix  d'acquisition", type = "double" });
          
            list.Add(new ComboItems() { id = 16, nom = "Compte d'immobilisation", type = "string" });

            list.Add(new ComboItems() { id = 17, nom = "Mode d'amortissement", type = "string" });
            list.Add(new ComboItems() { id = 18, nom = "duree d'amortissement", type = "int" });
            list.Add(new ComboItems() { id = 19, nom = "base amortissable", type = "string" });
            list.Add(new ComboItems() { id = 20, nom = "Amortissement  Ant ", type = "string" });
            list.Add(new ComboItems() { id = 21, nom = "code localisation", type = "string" });
            CmbcolumnHeader.ItemsSource = list;
            CmbcolumnHeader.SelectionChanged += (sender, args) => CmbcolumnHeader_SelectionChanged(sender, args);
        }

        private void CmbcolumnHeader_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var col = GetParent(sender as ComboBox, typeof(DataGridColumnHeader));
            if (col != null)
            {
                if ((sender as ComboBox).SelectedValue == null)
                {
                    if ((sender as ComboBox).SelectedItem != null)
                        (col as DataGridColumnHeader).Column.Header = ((sender as ComboBox).SelectedItem as ComboItems).nom;
                }
                else
                    (col as DataGridColumnHeader).Column.Header = (sender as ComboBox).SelectedValue;
            }
        }
        private FrameworkElement GetParent(FrameworkElement child, Type targetType)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            if (parent != null)
            {
                if (parent.GetType() == targetType)
                {
                    return (FrameworkElement)parent;
                }
                else
                {
                    return GetParent((FrameworkElement)parent, targetType);
                }
            }
            return null;
        }
    }
    public class ComboItems
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string type { get; set; }
        public ComboItems() { }
    }
}
