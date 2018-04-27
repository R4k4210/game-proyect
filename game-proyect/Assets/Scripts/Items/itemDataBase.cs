using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDataBase : MonoBehaviour {

    private void Start()
    {
        foreach (KeyValuePair<string, string> items in I18n.Fields) {
            Debug.Log(items.Key);
            Debug.Log(items.Value);
        }
        Debug.Log(ResourcesLoader.weaponDataBase[1].Title);
        Debug.Log(I18n.Fields[ResourcesLoader.weaponDataBase[1].Title] + " " + 
                  I18n.Fields[ResourcesLoader.weaponDataBase[0].Title]);
    }

}
