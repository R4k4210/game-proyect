using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

    public Object siguienteEscena;


    public void NextScene(int asd)
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
