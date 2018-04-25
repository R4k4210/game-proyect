using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGeneral : MonoBehaviour {

    public GameObject player;
    public EntidadPersonaje personaje;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(player);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
