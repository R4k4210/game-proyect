using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


/**
 * Load all json resources (weapons, consumables, armors, maps, npc, etc..)
 */ 
public class ResourcesLoader : MonoBehaviour {

    private static JsonData weaponData;
    public static Dictionary<int, Weapons> indexedWeaponsDataBase = new Dictionary<int, Weapons>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        Debug.Log("Getting all data from Json");
        weaponData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items/Weapons/Weapons.json"));
        Debug.Log("Calling the data constructor a");
        ContructWeaponDataBase();

    }

    /// <summary>
    /// Create the Weapons Disctionary from JSON File used as data base.
    /// </summary>
    static void ContructWeaponDataBase()
    {
        for (int i = 0; i < weaponData.Count; i++)
        {
            if ((bool)weaponData[i]["range"]["ranged"] == true)
            {
                indexedWeaponsDataBase.Add((int)weaponData[i]["id"], new Weapons((int)weaponData[i]["id"],
                                                                                      weaponData[i]["title"].ToString(),
                                                                                      weaponData[i]["description"].ToString(),
                                                                                 (int)weaponData[i]["atk"],
                                                                                (bool)weaponData[i]["stackable"],
                                                                                      weaponData[i]["slug"].ToString(),
                                                                                 (int)weaponData[i]["value"],
                                                                                (bool)weaponData[i]["range"]["ranged"],
                                                                                 (int)weaponData[i]["range"]["distance"],
                                                                                 (int)weaponData[i]["range"]["speed"]));
            }
            else {
                indexedWeaponsDataBase.Add((int)weaponData[i]["id"], new Weapons((int)weaponData[i]["id"],
                                                                                      weaponData[i]["title"].ToString(),
                                                                                      weaponData[i]["description"].ToString(),
                                                                                 (int)weaponData[i]["atk"],
                                                                                (bool)weaponData[i]["stackable"],
                                                                                      weaponData[i]["slug"].ToString(),
                                                                                 (int)weaponData[i]["value"],
                                                                                (bool)weaponData[i]["range"]["ranged"]));
                                                                              
            }
        }
    }
}
