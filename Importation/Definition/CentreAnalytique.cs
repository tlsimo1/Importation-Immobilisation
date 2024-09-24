using GeneraFi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperAttribute = Dapper.Contrib.Extensions;

namespace Importation.Definition
{
    [DapperAttribute.Table("CentreAnalytique")]
    class CentreAnalytique : EntityBase
    {
        private string _centreAnaly;
        [DapperAttribute.Key]
        [Column("Code", Groupe = "Information",Width =200)]
        public string centreAnaly
        {
            get
            {
                return _centreAnaly;
            }

            set
            {
                _centreAnaly = value;
                OnPropertyChanged("centreAnaly");

            }
        }
        private string _designation;
        [Column("Designation", Groupe = "Information", Width = 200)]
        public string designation
        {
            get
            {
                return _designation;
            }

            set
            {
                _designation = value;
                OnPropertyChanged("designation");

            }
        }
        public CentreAnalytique()
        {

        }
    }
}
