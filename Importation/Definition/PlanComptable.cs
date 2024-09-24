// File:    PlanComptable.cs
// Author:  Mohamed
// Created: jeudi 2 mai 2013 14:37:16
// Purpose: Definition of Class PlanComptable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperAttribute = Dapper.Contrib.Extensions;
using GeneraFi.Infrastructure;


namespace Definition
{
    [DapperAttribute.Table("PlanComptable")]
    public class PlanComptable: EntityBase
    {
        private string _numCompte;
        private string _designation;

        #region get/set
        [Column("NumCompte", Visible = true, VisibleG = true, Groupe = "Information",Width =270)]
        public String NumCompte
        {
            get { return _numCompte; }
            set { _numCompte = value; OnPropertyChanged("NumCompte"); }
        }
        [DapperAttribute.Computed]

        [Column("Designation", Groupe = "Information", Visible = true, VisibleG = true,Width =270)]
        public String Designation
        {
            get { return _designation; }
            set { _designation = value; OnPropertyChanged("Designation"); }
        }
       
     
     

        #endregion
        public PlanComptable()
        {
        }
        
    }
}