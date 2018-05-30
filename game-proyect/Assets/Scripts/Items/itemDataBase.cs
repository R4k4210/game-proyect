using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDataBase : MonoBehaviour {

    private void Start()
    {
        for (int i = 0; i< ResourcesLoader.indexedWeaponsDataBase.Count; i++) {
            Weapons w = new Weapons();
            ResourcesLoader.indexedWeaponsDataBase.TryGetValue(i, out w);
            Debug.Log(w.ToString());
        }
    }

}
