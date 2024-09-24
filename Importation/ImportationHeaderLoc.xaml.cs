using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Importation
{
    /// <summary>
    /// Logique d'interaction pour ImportationHeaderLoc.xaml
    /// </summary>
    public partial class ImportationHeaderLoc : UserControl
    {
        public ImportationHeaderLoc()
        {
            InitializeComponent();
            List<ComboItemsLocalisation> list = new List<ComboItemsLocalisation>();
            list.Add(new ComboItemsLocalisation() { id = 1, nom = "Niv1" });
            list.Add(new ComboItemsLocalisation() { id = 2, nom = "Niv2" });
            list.Add(new ComboItemsLocalisation() { id = 3, nom = "Niv3" });
            CmbcolumnHeader2.ItemsSource = list;
            CmbcolumnHeader2.SelectionChanged += (sender, args) => CmbcolumnHeader2_SelectionChanged(sender, args);
        }

        private void CmbcolumnHeader2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var col = GetParent(sender as ComboBox, typeof(DataGridColumnHeader));
            if (col != null)
            {
                if ((sender as ComboBox).SelectedValue == null)
                {
                    if ((sender as ComboBox).SelectedItem != null)
                        (col as DataGridColumnHeader).Column.Header = ((sender as ComboBox).SelectedItem as ComboItemsLocalisation).nom;
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
    public class ComboItemsLocalisation
    {
        public int id { get; set; }
        public string nom { get; set; }
        public ComboItemsLocalisation() { }
    }
}
