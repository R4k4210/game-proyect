using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class GeneralManager : MonoBehaviour {

    public GameObject player;
    public GameObject camara;
    public Vector3 startpoint;
    public GameObject CurrentTileMap;
    public CharacterEntity personaje;
    public Tile tile;

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
        stats.name = "Erdrako";
        stats.Level = 1;
        stats.BaseDamage = 10;
        stats.BaseDefense = 10;
        stats.Hp = 100;
        stats.MoveSpeed = 2;
        camara = (GameObject)Instantiate(camara, new Vector3(startpoint.x, startpoint.y, -600), camara.transform.rotation);

    }

    // Use this for initialization
    void Start () {
        
        

		
	}
	
	// Update is called once per frame
	void Update () {
        CamaraPosicion();
        //Debug.Log(CurrentTileMap.GetComponent<Tilemap>().GetTile(new Vector3Int((Int32)player.transform.position.x, (Int32)player.transform.position.y,(Int32)player.transform.position.z)).name);
        //CurrentTileMap.GetComponent<Tilemap>().SetTile(new Vector3Int((Int32)player.transform.position.x, (Int32)player.transform.position.y, (Int32)player.transform.position.z), CurrentTileMap.GetComponent<Tilemap>().GetTile(new Vector3Int((Int32)player.transform.position.x, (Int32)player.transform.position.y, (Int32)player.transform.position.z)));
        //CurrentTileMap.GetComponent<Tilemap>().SetTile(new Vector3Int((Int32)player.transform.position.x, (Int32)player.transform.position.y, (Int32)player.transform.position.z),tile);
    }
}
