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
    //public List<Armor> armorDataBase = new List<Armor>();
    //public List<Miscellaneous> miscellaneousDataBase = new List<Miscellaneous>();
    //public List<Consumable> consumableDataBase = new List<Consumable>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        Debug.Log("Getting all data from Json");
        weaponData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items/Weapons/Weapons.json"));
        Debug.Log("Calling the data constructor");
        ContructWeaponDataBase();

    }

    static void ContructWeaponDataBase()
    {
        for (int i = 0; i < weaponData.Count; i++)
        {
            indexedWeaponsDataBase.Add((int) weaponData[i]["id"], new Weapons((int)weaponData[i]["id"],
                                                                           weaponData[i]["title"].ToString(),
                                                                           weaponData[i]["description"].ToString(),
                                                                      (int)weaponData[i]["atk"],
                                                                      (int)weaponData[i]["value"]));
        }
    }
}
