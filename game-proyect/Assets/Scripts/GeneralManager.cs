using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour {

    public GameObject player;
    public GameObject camara;
    public Vector3 startpoint;
    public CharacterEntity personaje;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(player);
        CargarPersonajeDummy();
    }

    private void CamaraPosicion()
    {
        camara.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-600);
    }

    private void CargarPersonajeDummy()
    {

        player = (GameObject)Instantiate(player, startpoint, player.transform.rotation);
        CharacterEntity stats = player.GetComponent<CharacterEntity>();
        stats.Nombre = "Erdrako";
        stats.Nivel = 1;
        stats.DañoBase = 10;
        stats.DefensaBase = 10;
        stats.Hp = 100;
        stats.Velocidad = 2;
        camara = (GameObject)Instantiate(camara, new Vector3(startpoint.x, startpoint.y, -600), camara.transform.rotation);

    }

    // Use this for initialization
    void Start () {
        
        

		
	}
	
	// Update is called once per frame
	void Update () {
        CamaraPosicion();
	}
}
