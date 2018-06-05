using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    public int id { get; set; }
    public string title { get; set; }
    public string description { get; private set; }
    public List<Goal> goals { get; private set; }


    public Quest(int id, string title, string description, List<Goal> goals) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.goals = goals;
    }

    /// <summary>
    ///     Gets the quest progression
    /// </summary>
    /// <returns>Percentage representation of how many goals were completed</returns>
    public double getProgress() {
        int qGoalsCompleted = goals.FindAll(goal => goal.status.Equals(GoalStatus.COMPLETED)).Count;
        return (((double) qGoalsCompleted / goals.Count) * 100);
    }

    /// <summary>
    /// Checks if the Quest is completed
    /// </summary>
    /// <returns>true or false</returns>
    public bool isCompleted() {
        return (getProgress() == 100);
    }

    /// <summary>
    /// Searchs for a Goal with given entityID and Goal type
    /// </summary>
    /// <param name="entityID">the entityID</param>
    /// <param name="type">the Goal Type</param>
    /// <returns>A Goal if found or null</returns>
    public List<Goal> findApplicableGoals(int entityID, GoalType type){
        return goals.FindAll(g => (g.entityID == entityID && g.type.Equals(type)));
    }

}
