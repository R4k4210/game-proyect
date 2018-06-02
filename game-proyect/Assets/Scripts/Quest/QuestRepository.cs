using LitJson;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class QuestRepository{

    private Dictionary<int, Quest> quests;

    public QuestRepository() {
        this.loadQuests();
    }

    /// <summary>
    ///     Loads up JSON file with Quests configuration and transforms it to a Quest Dictionary.
    /// </summary>
    public void loadQuests() {
        Debug.Log("Loading Quests...");
        JsonData questsJSON = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Quests/Quests.json"));
        quests = buildQuestsFromJSON(questsJSON);
    }

    /// <summary>
    ///  Gets all Quests from repository
    /// </summary>
    /// <returns>List of Quests</returns>
    public List<Quest> getQuests() {
        return this.quests.Values.ToList();
    }

    /// <summary>
    ///     Gets a Quest for given questID
    /// </summary>
    /// <param name="questID">the questID</param>
    /// <returns>Quest if found or null</returns>
    public Quest getQuest(int questID){
        return this.quests[questID];
    }

    private Dictionary<int, Quest> buildQuestsFromJSON(JsonData questsJSON)
    {
        Dictionary<int, Quest> quests = new Dictionary<int, Quest>();
        for (int i = 0; i < questsJSON.Count; i++)
        {

            int questID = (int)questsJSON[i]["id"];
            List<Goal> goals = this.buildGoalsForQuest(questsJSON[i]["goals"]);

            Quest quest = new Quest(questID,
                                    questsJSON[i]["title"].ToString(),
                                    questsJSON[i]["description"].ToString(),
                                    goals);


            quests.Add(questID, quest);

        }

        return quests;
    }

    private List<Goal> buildGoalsForQuest(JsonData goalsJSON)
    {
        List<Goal> goals = new List<Goal>();
        for (int i = 0; i < goalsJSON.Count; i++)
        {
            GoalType goalType = (GoalType)Enum.Parse(typeof(GoalType), goalsJSON[i]["type"].ToString());
            Goal goal = new Goal(goalType,
                                 (int)goalsJSON[i]["entityID"],
                                 (int)goalsJSON[i]["quantityNeeded"]);

            goals.Add(goal);
        }
        return goals;
    }
}
