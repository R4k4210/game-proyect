using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

    public Object siguienteEscena;


    public void SiguienteEscena()
    {
        SceneManager.LoadScene(siguienteEscena.name);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
