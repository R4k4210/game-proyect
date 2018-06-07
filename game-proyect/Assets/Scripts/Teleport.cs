using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {


    public TeleportType teleportType;
    public string target;
    public Vector3Int VectorTarget;
    public GameObject Objetive;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Objetive != null)
        {
            collision.gameObject.transform.position = Objetive.transform.position;
        }
        else
        {
            Debug.Log("Referencia al objetivo nula en Teleport.cs");
        }
        
    }

    
    void Start () {
        switch (teleportType)
        {
            case TeleportType.Coordenadas:
                try
                {
                    Objetive = new GameObject();
                    Objetive.transform.position = VectorTarget;
                }
                catch
                {
                    Debug.Log("Error Procesando las coordenadas en Teleport.cs");
                }
                
                break;
            case TeleportType.Nombre:
                try
                {
                    Objetive = GameObject.Find(target);
                }
                catch
                {
                    Debug.Log("Error Procesando el nombre del objetivo en Teleport.cs");
                }
                
                break;
            case TeleportType.Referencia:
                try
                {
                    Objetive = Objetive;
                }
                catch
                {
                    Debug.Log("Error Procesando la referencia del objeto en Teleport.cs");
                }
                
                break;
            default:
                break;
        }
        
	}

}

/// <summary>
/// Tipo de referencia que se va a utilizar para el teleport.
/// </summary>
public enum TeleportType { Nombre,Coordenadas,Referencia}