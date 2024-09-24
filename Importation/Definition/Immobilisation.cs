

using System;
using System.Collections.Generic;
using System.Linq;

namespace Definition
{
    public class Immobilisation 
    {
        private int _idImmo;
        private int _idEntree;
        private Double _prixAcquisition;
        private DateTime _dateMiseEnService;
        private DateTime _dateRetrait;
        private bool _retrait;
        private Double _valeurCession;
        private int _provenance;
        private double _baseAmortissable;
        private string _type;
        private DateTime _dateAcquisition;
        private String _designation;
        private String _numGroupe;
        private String _localisation;
        private String _compte;
        private String _modeAmortissement;
        private float _dureeAmortissement;
        private int _qte;
        private double _tva;
        private List<AffCentreAnaly> _centresAnalytique;
        private List<AffLocalisation> _localisations;
        private List<AffPlanComptable> _comptes;
        private List<ModeAmortissement> _modeAmortissements;
        private Amortissement _valAmortissementAnterieur;
        private String _nomFournisseur;
        private double _amortAnterieur;
        private bool _present = true;
        public bool CAExiste { get; set; }
        public bool Inventoriable { get; set; }
        public int DureeAmortissementMois { get; set; }
        public DateTime DateAmoAnt { get; set; }
        public String NumGroupePere { get; set; }
        public int RowVersion { get; set; }
        public string SourceNumGroupe { get; set; }
        public String SysModifiedUser { get; set; }
        public DateTime SysModifiedDate { get; set; }
        public DateTime SysCreatedDate { get; set; }

        public String Famille { get; set; }
        public String Reference = "";
        public String NumFact = "";
        public bool Derogatoire = false;
        public bool Grouper = false;

        public String ModeAmortissementFisc = "";
        public float DureeAmortissementFisc=0;
        public double AmortAnterieurFisc=0;
        public float DureeAmortissementFiscEtr = 0;
        public double AmortAnterieurFiscEtr = 0;
        public String Sequenceur = "";
        public int Categorie = 0;
        public int QteCodeBare = 0;
        public String CodeBarre = "";
        public String CatCDG { get; set; }
        public String Obs { get; set; }
        public String Tag { get; set; }
        public String NumPO { get; set; }
        public String CAPEX { get; set; }
        public float DureeUSGAAP { get; set; }
        public Double AmoAntrUSGAAP { get; set; }
        private int _idFacture = 0;
        private Double _baseAmortissableEtr = 0;
        private DateTime _dateGroupement;
        private String _modele;

      

        private String _etatDuBien;

        public String EtatDuBien
        {
            get { return _etatDuBien; }
            set { _etatDuBien = value; }
        }

        private String _numSerie;

        public String NumSerie
        {
            get { return _numSerie; }
            set { _numSerie = value; }
        }
        public DateTime DateGroupement
        {
            get { return _dateGroupement; }
            set { _dateGroupement = value; }
        }
        public Double BaseAmortissableEtr
        {
            get { return _baseAmortissableEtr; }
            set { _baseAmortissableEtr = value; }
        }
        private String _modeAmortissementEtr = "";

        public String ModeAmortissementEtr
        {
            get { return _modeAmortissementEtr; }
            set { _modeAmortissementEtr = value; }
        }
        public int IdFacture
        {
            get { return _idFacture; }
            set { _idFacture = value; }
        }
        private double _amortCumul = 0;
        public double AmortCumul
        {
            get { return _amortCumul; }
            set { _amortCumul = value; }
        }
        private double _amortCumulEtr = 0;

        public double AmortCumulEtr
        {
            get { return _amortCumulEtr; }
            set { _amortCumulEtr = value; }
        }
        #region get/set
        public bool Present
        {
            get { return _present; }
            set { _present = value; }
        }
        //public Amortissement ValAmortissementAnterieur
        //{
        //    get { return _valAmortissementAnterieur; }
        //    set { _valAmortissementAnterieur = value; }
        //}
        public double Tva
        {
            get { return _tva; }
            set { _tva = value; }
        }
        public int Qte
        {
            get { return _qte; }
            set { _qte = value; }
        }
        public double AmortAnterieur
        {
            get { return _amortAnterieur; }
            set { _amortAnterieur = value; }
        }
        public String NomFournisseur
        {
            get { return _nomFournisseur; }
            set { _nomFournisseur = value; }
        }
        public String ModeAmortissement
        {
            get { return _modeAmortissement; }
            set { _modeAmortissement = value; }
        }

        public float DureeAmortissement
        {
            get { return _dureeAmortissement; }
            set { _dureeAmortissement = value; }
        }
        public string Localisation
        {
            get { return _localisation; }
            set { _localisation = value; }
        }
        public String Compte
        {
            get { return _compte; }
            set { _compte = value; }
        }
        public String NumGroupe
        {
            get { return _numGroupe; }
            set { _numGroupe = value; }
        }
        public String Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public double BaseAmortissable
        {
            get { return _baseAmortissable; }
            set { _baseAmortissable = value; }
        }
        public DateTime DateAcquisition
        {
            get { return _dateAcquisition; }
            set { _dateAcquisition = value; }
        }
        public List<ModeAmortissement> ModeAmortissements
        {
            get { return _modeAmortissements; }
            set { _modeAmortissements = value; }
        }
        public List<AffPlanComptable> Comptes
        {
            get { return _comptes; }
            set { _comptes = value; }
        }
        public List<AffLocalisation> Localisations
        {
            get { return _localisations; }
            set { _localisations = value; }
        }
        public List<AffCentreAnaly> CentresAnalytique
        {
            get { return _centresAnalytique; }
            set { _centresAnalytique = value; }
        }
        public int IdImmo
        {
            get { return _idImmo; }
            set { _idImmo = value; }
        }
        public int IdEntree
        {
            get { return _idEntree; }
            set { _idEntree = value; }
        }
        public DateTime DateMiseEnService
        {
            get { return _dateMiseEnService; }
            set { _dateMiseEnService = value; }
        }
        public DateTime DateRetrait
        {
            get { return _dateRetrait; }
            set { _dateRetrait = value; }
        }
        public bool Retrait
        {
            get { return _retrait; }
            set { _retrait = value; }
        }
        public Double ValeurCession
        {
            get { return _valeurCession; }
            set { _valeurCession = value; }
        }
        public Double PrixAcquisition
        {
            get { return _prixAcquisition; }
            set { _prixAcquisition = value; }
        }
        public int Provenance
        {
            get { return _provenance; }
            set { _provenance = value; }
        }

        private String _etatImmo = "";
        public String EtatImmo
        {
            get { return _etatImmo; }
            set { _etatImmo = value; }
        }
        public String Motif = "";
        public List<CodeBarre> ListCodeBarre = null;
        #endregion
       
     
    }
}