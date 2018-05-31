using LitJson;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class QuestRepository{

    private Dictionary<int, Quest> quests;

    public void loadQuests() {
        Debug.Log("Loading Quests...");
        JsonData questsJSON = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Quests/Quests.json"));
        quests = buildQuestsFromJSON(questsJSON);
    }

    private Dictionary<int, Quest> buildQuestsFromJSON(JsonData questsJSON)
    {
        Dictionary<int, Quest> quests = new Dictionary<int, Quest>();
        for (int i = 0; i < questsJSON.Count; i++) {



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

        return quests;
    }

    public List<Quest> getQuests() {
        return this.quests.Values.ToList();
    }

    public Quest getQuest(int questID){
        return this.quests[questID];
    }
}
