

using System;
namespace Definition
{
    public class AffPlanComptable
    {
        private String _compte;
        private int _idImmo;
        private DateTime _dateAff;
        private int _cle;

       
        #region get/set
        public int Cle
        {
            get { return _cle; }
            set { _cle = value; }
        }
        public String Compte
        {
            get { return _compte; }
            set { _compte = value; }
        }
        public int IdImmo
        {
            get { return _idImmo; }
            set { _idImmo = value; }
        }
        public DateTime DateAff
        {
            get { return _dateAff; }
            set { _dateAff = value; }
        }
        #endregion

        public AffPlanComptable() { }
        public AffPlanComptable(string compte,int idImmo,string dateAff) 
        {
            _compte = compte;
            _idImmo = idImmo;
            _dateAff = DateTime.Parse(dateAff);
        }


    }
}