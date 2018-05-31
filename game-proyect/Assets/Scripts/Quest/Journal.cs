using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Journal
{
    public List<Quest> questsInProgress { get; set; }
    public List<Quest> questsCompleted { get; set; }

    public void takeQuest(int questID) {
        Quest quest = new Quest(); //TODO: get quest from repository
        questsInProgress.Add(quest);
    }

    public void dismissQuest(int questID){
        questsInProgress.Remove(questsInProgress.Find(quest => quest.id == questID));      
    }

    public void registerProgress(int entityID, GoalType goalType, int quantity, JournalAction action) {
        questsInProgress.FindAll(q => (q.hasGoalForTypeAndEntity(entityID, goalType))).ConvertAll(q => q.goals)
                        .ForEach(goals => goals.ForEach(goal => {
                            if (action.Equals(JournalAction.ADD)) {
                                goal.addQuantityDone(quantity);
                            } else if (action.Equals(JournalAction.ADD)){
                                goal.removeQuantityDone(quantity);
                            }
                        })            
                     );
        
        questsCompleted.AddRange(questsInProgress.FindAll(q => q.getProgress() == 100));
        questsInProgress.FindAll(q => q.getProgress() == 100)
                        .ForEach(q => this.dismissQuest(q.id));
    }
}