using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEvents : MonoBehaviour {

    //TODO: Move event behaviours to definitive Item behaviour class
    public int entityID;
    public int quantity;

    public static ItemEvents instance = null;

    public delegate void ItemPickupDelegate(int entityID, int quantity);
    public static event ItemPickupDelegate itemPickupEvent;

   

    void Awake() {
        if (instance == null) { 
            instance = this;
        }        
    }

    void Start() { }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            itemPickUp(this.entityID, this.quantity);
        }
    }

    void itemPickUp(int entityID, int quantity) {
        if (itemPickupEvent != null) {
            itemPickupEvent(entityID, quantity);
        }
    }

    
}
