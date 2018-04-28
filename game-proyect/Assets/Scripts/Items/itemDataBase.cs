using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDataBase : MonoBehaviour {

    private void Start()
    {
        Weapons w = new Weapons();
        ResourcesLoader.indexedWeaponsDataBase.TryGetValue(0, out w);
        Debug.Log(I18n.Fields[w.Title]);
    }

}
