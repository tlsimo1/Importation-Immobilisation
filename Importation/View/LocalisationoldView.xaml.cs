﻿using Business;
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
    /// Logique d'interaction pour LocalisationView.xaml
    /// </summary>
    public partial class LocalisationView : Window
    {
        public LocalisationView( int niveau)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            grilleLocalisation.TypeSrc = typeof(Localisations);
            grilleLocalisation.BusinessSrc = new BLocalisation();
            grilleLocalisation.Condition = $"NiveauLoc={niveau}";
            grilleLocalisation.DictDefaultValue["NiveauLoc"] = niveau;
            grilleLocalisation.PrepaAjout();
        }
    }
}
