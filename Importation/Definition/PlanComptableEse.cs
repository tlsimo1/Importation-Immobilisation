using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperAttribute = Dapper.Contrib.Extensions;
using GeneraFi.Infrastructure;

namespace Definition
{
    [DapperAttribute.Table("PlanComptableEse")]
   public class PlanComptableEse: EntityBase
    {
        private string _compte;
        private string _compteAmo;
        private string _compteDot;
    
        [DapperAttribute.Key]
        [Column("Compte d'immobilation", Visible = true, VisibleG = true,Groupe = "Information",Width =100)]
        public string Compte
        {
            get
            {
                return _compte;
            }

            set
            {
                _compte = value;
                OnPropertyChanged("Compte");
            }
        }
    

        [Column("Compte d'amortissement", Groupe = "Information", Visible = true, VisibleG = true, Width = 150)]
        public string CompteAmo
        {
            get
            {
                return _compteAmo;
            }

            set
            {
                _compteAmo = value;
                OnPropertyChanged("CompteAmo");
            }
        }
      
        [Column("Compte de dotation", Groupe = "Information", Visible = true, VisibleG = true, Width = 100)]
        public string CompteDot
        {
            get
            {
                return _compteDot;
            }

            set
            {
                _compteDot = value;
                OnPropertyChanged("CompteDot");
            }
        }
        public PlanComptableEse()
        {

        }

    }
}
