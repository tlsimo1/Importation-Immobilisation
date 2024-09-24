

using System;
namespace Definition
{
    public class AffCentreAnaly
    {
        private int _taux;
        private DateTime _dateAff;
        private int _idImmo;
        private String _centreAnaly;
        public int CleOrder;
        #region get/set
        public String CentreAnaly
        {
            get { return _centreAnaly; }
            set { _centreAnaly = value; }
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
        public int Taux
        {
            get { return _taux; }
            set { _taux = value; }
        }
        #endregion
        public AffCentreAnaly(String taux, string dateAff, int idImmo, string centerAnaly)
        {
            _centreAnaly = centerAnaly;
            _idImmo = idImmo;
            _taux = int.Parse(taux);
            _dateAff = DateTime.Parse(dateAff);
        }
        public AffCentreAnaly() { }
    }
}