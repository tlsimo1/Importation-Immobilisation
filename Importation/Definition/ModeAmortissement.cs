
using System;
namespace Definition
{
    public class ModeAmortissement
    {
        private int _idModAmo;
        private int _idImmo;
        private String _modAmo;
        private float _dureeAmo;
        private DateTime _dateAff;
        private int _cle;

       
        #region get/set
        public int Cle
        {
            get { return _cle; }
            set { _cle = value; }
        }
        public int IdModAmo
        {
            get { return _idModAmo; }
            set { _idModAmo = value; }
        }
        public int IdImmo
        {
            get { return _idImmo; }
            set { _idImmo = value; }
        }
        public String ModAmo
        {
            get { return _modAmo; }
            set { _modAmo = value; }
        }
        public float DureeAmo
        {
            get { return _dureeAmo; }
            set { _dureeAmo = value; }
        }
        public DateTime DateAff
        {
            get { return _dateAff; }
            set { _dateAff = value; }
        }
        #endregion
        public ModeAmortissement() { }
        public ModeAmortissement(int idImmo,string modeAmo,String dureeAmo,string dateAff) 
        {
            _idImmo = idImmo;
            _modAmo = modeAmo;
            _dureeAmo= int.Parse(dureeAmo);
            _dateAff = DateTime.Parse(dateAff);
        }


    }
}