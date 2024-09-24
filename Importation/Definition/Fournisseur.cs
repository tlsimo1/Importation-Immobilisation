using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperAttribute = Dapper.Contrib.Extensions;

namespace Importation.Definition
{

    [DapperAttribute.Table("Fournisseur")]
    public class Fournisseur : EntityBase
    {
        private string _codeFrs;
        [DapperAttribute.Key]
        [Column("Code Fournisseur", Groupe = "Information")]
        public string codeFrs
        {
            get
            {
                return _codeFrs;
            }

            set
            {
                _codeFrs = value;
                OnPropertyChanged("codeFrs");

            }
        }

        private string _nomFournis;
        [Column("Nom", Groupe = "Information")]
        public string nomFournis
        {
            get
            {
                return _nomFournis;
            }

            set
            {
                _nomFournis = value;
                OnPropertyChanged("nomFournis");

            }
        }

        private string _adresseFournis;
        [Column("Adresse", Groupe = "Information")]
        public string adresseFournis
        {
            get
            {
                return _adresseFournis;
            }

            set
            {
                _adresseFournis = value;
                OnPropertyChanged("adresseFournis");

            }
        }

        private string _emailFounis;
        [Column("Email", Groupe = "Information")]
        public string emailFounis
        {
            get
            {
                return _emailFounis;
            }

            set
            {
                _emailFounis = value;
                OnPropertyChanged("emailFounis");

            }
        }

        private string _telFournis;
        [Column("Tel", Groupe = "Information")]
        public string telFournis
        {
            get
            {
                return _telFournis;
            }

            set
            {
                _telFournis = value;
                OnPropertyChanged("telFournis");

            }
        }

        private string _faxFournis;
        [Column("Fax", Groupe = "Information")]
        public string faxFournis
        {
            get
            {
                return _faxFournis;
            }

            set
            {
                _faxFournis = value;
                OnPropertyChanged("faxFournis");

            }
        }

        private string _responsableFournis;
        [Column("Responsable", Groupe = "Information" )]
        public string responsableFournis
        {
            get
            {
                return _responsableFournis;
            }

            set
            {
                _responsableFournis = value;
                OnPropertyChanged("responsableFournis");

            }
        }

        public Fournisseur()
        {

        }
    }
}
