using Importation.Business;
using Importation.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Importation.View
{
    /// <summary>
    /// Logique d'interaction pour CentreAnalytiqueView.xaml
    /// </summary>
    public partial class CentreAnalytiqueView : Window
    {
        public CentreAnalytiqueView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            GrillecentreAnalytique.TypeSrc = typeof(CentreAnalytique);
            GrillecentreAnalytique.BusinessSrc = new BCentreAnalytique();
            GrillecentreAnalytique.PrepaAjout();
        }

        private void GrillecentreAnalytique_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
