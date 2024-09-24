

using System;

public class Amortissement
{
    private int _idAmo;
    private int _idImmo;
    private DateTime _dateAmo;
    private Double _valeurAmo;
    #region get/set
    public int IdAmo
    {
        get { return _idAmo; }
        set { _idAmo = value; }
    }
    
    public int IdImmo
    {
        get { return _idImmo; }
        set { _idImmo = value; }
    }


    public DateTime DateAmo
    {
        get { return _dateAmo; }
        set { _dateAmo = value; }
    }

    public Double ValeurAmo
    {
        get { return _valeurAmo; }
        set { _valeurAmo = value; }
    }

    #endregion
    public Amortissement(int idamo,int idimmo,DateTime dateamo,Double valamo)
    {
    _idAmo= idamo; _idImmo=idimmo;_valeurAmo=valamo;_dateAmo= dateamo;
    }
}