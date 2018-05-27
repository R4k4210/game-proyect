using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ContainerFactory is a reusable class for any type of container, allways needs a Container GameObject.
/// Under the main container "Slot Panel" named GameObject is needed. Slot Amount is the amount of slots.
/// Slot and Item are the prefab slot and item GameObjects.
/// </summary>
public class ContainerFactory : MonoBehaviour {
    public int slotAmount { get; set; }
    GameObject[] containers;
    GameObject container;
    GameObject slotPanel;
    public GameObject slot;
    public GameObject item;

    List<GameObject> slots = new List<GameObject>();


    public void InitializeContainer() {

        container = this.gameObject;

        slotPanel = container.transform.Find("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(slot));
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }

}
