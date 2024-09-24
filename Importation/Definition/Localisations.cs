using GeneraFi.Infrastructure;
using System;
using DapperAttribute = Dapper.Contrib.Extensions;
namespace Definition
{
    [DapperAttribute.Table("Localisation")]
    public class Localisations : EntityBase
    {
        private int id_Loc;
        private String _localisation;
        private String _designation;
        private int _niveauLoc;
        private int _id_Loc_Supp;
        private bool _isInv;
        private string _respensable;
        private string _superieur;
        private String _fullPath;
        [DapperAttribute.Key]
   
        public int Id_Loc
        {
            get
            {
                return id_Loc;
            }
            set
            {
                id_Loc = value; OnPropertyChanged("Id_Loc");
            }
        }
        [Column("Localisation ", Visible = true, VisibleG = true, Groupe = "Information", Width = 200)]
        public string Localisation
        {
            get
            {
                return _localisation;
            }
            set
            {
                _localisation = value; OnPropertyChanged("Localisation");
            }
        }
        [Column("Désignation", Visible = true, VisibleG = true, Groupe = "Information", Width = 200)]
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value; OnPropertyChanged("Designation");
            }
        }
        public int NiveauLoc
        {
            get
            {
                return _niveauLoc;
            }
            set
            {
                _niveauLoc = value; OnPropertyChanged("NiveauLoc");
            }
        }
      
        [Column("Loc sup", Visible = true, VisibleG = true, Groupe = "Information", Width = 200)]
        [InfoSource("Localisation", "localisation", "Id_Loc")]
        public int Id_Loc_Supp
        {
            get
            {
                return _id_Loc_Supp;
            }
            set
            {
                _id_Loc_Supp = value; OnPropertyChanged("Id_Loc_Supp");
            }
        }
        public bool IsInv
        {
            get
            {
                return _isInv;
            }
            set
            {
                _isInv = value; OnPropertyChanged("IsInv");
            }
        }
        public string Respensable
        {
            get
            {
                return _respensable;
            }
            set
            {
                _respensable = value; OnPropertyChanged("Respensable");
            }
        }
        public string FullPath
        {
            get
            {
                return _fullPath;
            }
            set
            {
                _fullPath = value; OnPropertyChanged("FullPath");
            }
        }
       
        [DapperAttribute.Computed]
        public string Superieur
        {
            get
            {
                return _superieur;
            }

            set
            {
                _superieur = value; OnPropertyChanged("Superieur");
            }
        }

        public Localisations()
        {

        }
    }
}