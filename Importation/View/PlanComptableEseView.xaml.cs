using Business;
using Definition;
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
    /// Logique d'interaction pour PlanComptableEseView.xaml
    /// </summary>
    public partial class PlanComptableEseView : Window
    {
        public PlanComptableEseView()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            grillePlanComptableEse.TypeSrc = typeof(PlanComptableEse);
            grillePlanComptableEse.BusinessSrc = new BPlanComptableEse();
            grillePlanComptableEse.PrepaAjout();
        }
    }
}
