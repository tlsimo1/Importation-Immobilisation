using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperAttribute = Dapper.Contrib.Extensions;


namespace Definition
{
    [DapperAttribute.Table("Categorie")]
    public class Categorie: EntityBase
    {
        private int _idCategorie;
        private String _designation;
        private int _parentId;
        private String _fils;
        private String _motCle;
        private int _isNivSupp;
        private string _parent;
        [DapperAttribute.Key]
        [InfoSource("Categorie", "Designation", "IdCategorie")]
        [Column("Id Categorie ", Visible = false, VisibleG = true, Groupe = "Information", Width = 100)]
        public int IdCategorie
        {
            get
            {
                return _idCategorie;
            }

            set
            {
                _idCategorie = value; OnPropertyChanged("IdCategorie");
            }
        }
        
        [Column("Designation", Visible = true, VisibleG = true, Groupe = "Information", Width = 200)]
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
      
        [Column("Parent_Id", Visible = false, VisibleG = false, Groupe = "Information", Width = 100)]
        public int Parent_Id
        {
            get
            {
                return _parentId;
            }

            set
            {
                _parentId = value; OnPropertyChanged("Parent_Id");
            }
        }
        [Column("Fils", Visible = false, VisibleG = false, Groupe = "Information", Width = 100)]
        public string Fils
        {
            get
            {
                return _fils;
            }

            set
            {
                _fils = value; OnPropertyChanged("Fils");
            }
        }
        [Column("Mots Clés*", Visible = false, VisibleG = false, Groupe = "Information", Width = 100)]
        public string MotCle
        {
            get
            {
                return _motCle;
            }

            set
            {
                _motCle = value; OnPropertyChanged("MotCle");
            }
        }
        [Column("IsNivSupp", Visible = false, VisibleG = false, Groupe = "Information", Width = 100)]
        public int IsNivSupp
        {
            get
            {
                return _isNivSupp;
            }
            set
            {
                _isNivSupp = value; OnPropertyChanged("IsNivSupp");
            }
        }
       
        [DapperAttribute.Computed]
        [Column("Categorie Parente ", Visible = true, VisibleG = true, Groupe = "Information", Width = 100)]
        public string Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent = value; OnPropertyChanged("Parent");
            }
        }

        public Categorie()
        {

        }
    }
}
