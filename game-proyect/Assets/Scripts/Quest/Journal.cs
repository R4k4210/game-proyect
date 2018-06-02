using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Journal
{
    public List<Quest> questsInProgress { get; }
    public List<Quest> questsCompleted { get; }
    public QuestRepository questRepository = new QuestRepository();

    public Journal() {
        questsInProgress = new List<Quest>();
        questsCompleted = new List<Quest>();
    }
    /// <summary>
    ///     Checks if the quest is already in progress list
    /// </summary>
    /// <param name="questID">the questID to check</param>
    /// <returns>true or false</returns>
    public bool hasQuestInProgress(int questID) {
        return (questsInProgress.Find(quest => quest.id == questID) != null);
    }

    /// <summary>
    ///  Adds the quest to in progress list if it isn't already taken
    /// </summary>
    /// <param name="questID">the questID to add</param>
    public void takeQuest(int questID) {
        if (!hasQuestInProgress(questID)) { 
            questsInProgress.Add(questRepository.getQuest(questID));
        }
    }

    /// <summary>
    ///  Removes the quest from the in progress list
    /// </summary>
    /// <param name="questID">the questID to remove</param>
    public void dismissQuest(int questID) {
        questsInProgress.Remove(questsInProgress.Find(quest => quest.id == questID));
    }

    /// <summary>
    ///     Registers progress to any quest goal for given entityID and goalType. Then moves it to quests completed
    ///     list if the quest progress reaches 100%
    /// </summary>
    /// <param name="entityID">the entityID from the entity that triggered the event</param>
    /// <param name="goalType">the goalType based on the event triggered</param>
    /// <param name="quantity">the quantity to add or substract to goal progress</param>
    /// <param name="action">the action determines the operation to apply to goal progress</param>
    public void registerProgress(int entityID, GoalType goalType, int quantity, JournalAction action) {
        questsInProgress.FindAll(q => (q.hasGoalForTypeAndEntity(entityID, goalType))).ConvertAll(q => q.goals)
                        .ForEach(goals => goals.ForEach(goal => {
                            if (action.Equals(JournalAction.ADD)) {
                                goal.addQuantityDone(quantity);
                            } else if (action.Equals(JournalAction.SUBSTRACT)) {
                                goal.removeQuantityDone(quantity);
                            }
                        })
                     );

        questsCompleted.AddRange(questsInProgress.FindAll(q => q.getProgress() == 100));
        questsInProgress.FindAll(q => q.getProgress() == 100)
                        .ForEach(q => this.dismissQuest(q.id));
    }
}