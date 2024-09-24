

using System;
namespace Definition
{
    public class AffLocalisation
    {

        private String _localisation;
        private int _idImmo;
        private DateTime _dateAff;
        private int _cle;

       
        #region get/set
        public int Cle
        {
            get { return _cle; }
            set { _cle = value; }
        }
        public int IdImmo
        {
            get { return _idImmo; }
            set { _idImmo = value; }
        }
        public String Localisation
        {
            get { return _localisation; }
            set { _localisation = value; }
        }
        public DateTime DateAff
        {
            get { return _dateAff; }
            set { _dateAff = value; }
        }
        #endregion
        public AffLocalisation(String loc,int idImmo,string dateAff) 
        {
            _localisation = loc;
            _idImmo = idImmo;
            _dateAff = DateTime.Parse(dateAff);
        }

        public AffLocalisation() { }
    }
}