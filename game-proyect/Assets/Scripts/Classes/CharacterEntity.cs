using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity :MonoBehaviour {

    protected string _nombre;
    protected int   _nivel;
    protected float _dañoBase;
    protected float _defensaBase;
    protected float _hp;
    protected float _velocidad;

    public string Nombre { get { return _nombre; } set { _nombre = value; } }
    public int Nivel { get { return _nivel; } set { _nivel = value; } }
    public float DañoBase { get { return _dañoBase; }set { _dañoBase = value; } }
    public float DefensaBase { get { return _defensaBase; }set { _defensaBase = value; } }
    public float Hp { get { return _hp; }set { _hp = value; } }
    public float Velocidad { get { return _velocidad; }set { _velocidad = value; } }
	
    public CharacterEntity(string Nombre,int Nivel,float DañoBase,float DefensaBase,float Hp,float Velocidad)
    {
        _nombre = Nombre;
        _nivel = Nivel;
        _dañoBase = DañoBase;
        _defensaBase = DefensaBase;
        _hp = Hp;
        _velocidad = Velocidad;
    }

    public CharacterEntity() { }
    

}
