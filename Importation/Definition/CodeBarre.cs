using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Definition
{
  public  class CodeBarre
    {
        public int IdCodeBarre { get; set; }
        public int IdImmo { get; set; }
        public String Code { get; set; }
        public int Check { get; set; }
        public string Local { get; set; }
        public String Sequenceur { get; set; }
        public int IsIMC { get; set; }
        public int IsNV { get; set; }
        public String Resp { get; set; }
        public int isChange { get; set; }
        public String User { get; set; }
        public String NumSerie { get; set; }
        public String EtatDuBien { get; set; }
        public int isAppliquer { get; set; }
        private Boolean _modifie=false;

        public Boolean Modifie
        {
            get { return _modifie; }
            set { _modifie = value; }
        }
        

  }
}
