using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VJTest : MonoBehaviour {

    public VJHandler jsMovement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(jsMovement.InputDirection);
	}
}
