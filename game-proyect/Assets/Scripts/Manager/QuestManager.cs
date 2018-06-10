using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    private Journal journal;

	// Use this for initialization
	void Start () {
        journal = new Journal();
        journal.takeQuest(0);
        ItemEvents.itemPickupEvent += pickupItem;

    }
	
    private void pickupItem(int entityID, int quantity) {
        this.journal.registerProgress(entityID, GoalType.RECOLLECT, quantity, JournalAction.ADD);
    }

    //Metodo para obtener misiones en curso y mostrar progreso
 
}
