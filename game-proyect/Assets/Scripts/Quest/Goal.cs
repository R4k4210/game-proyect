using UnityEngine;
using System.Collections;

public class Goal{
    public GoalType type { get; private set; }
    public GoalStatus status { get; set; }
    public int entityID { get; private set; }
    public int quantityNeeded { get; private set; }
    public int quantityDone { get; set; }

    public Goal(GoalType type, int entityID, int quantityNeeded) {
        this.type = type;
        this.entityID = entityID;
        this.quantityNeeded = quantityNeeded;
        this.status = GoalStatus.IN_PROGRESS;
        this.quantityDone = 0;
    }

    public void addQuantityDone(int quantity) {
        if (status.Equals(GoalStatus.IN_PROGRESS)) { 
            this.quantityDone += quantity;
            if (quantityDone >= quantityNeeded) {
                Debug.Log("Goal Completed");
                this.status = GoalStatus.COMPLETED;
            }
        }
    }

    public void removeQuantityDone(int quantity) {
        this.quantityDone -= quantity;
        if (quantityDone <= quantityNeeded) {
            this.status = GoalStatus.IN_PROGRESS;
        }
    }
}
