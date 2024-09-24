
using Business;
using Definition;
using GeneraFi.Infrastructure;
using Importation.Definition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UCGeneraFi;

namespace Importation
{
    /// <summary>
    /// Logique d'interaction pour FournisseurView.xaml
    /// </summary>
    public partial class FournisseurView : Window
    {
        public FournisseurView()
        {
            InitializeComponent();
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            grilleFournisseur.TypeSrc = typeof(Fournisseur);
            grilleFournisseur.BusinessSrc = new BFournisseur();
            grilleFournisseur.PrepaAjout();
         
        }
    }
}
