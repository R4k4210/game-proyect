using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    private Journal journal;

	// Use this for initialization
	void Start () {
        journal = new Journal();
        journal.takeQuest(0);
        journal.registerProgress();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Quests in progress: ");
        journal.questsInProgress.ForEach(
            quest => {
                Debug.Log(quest.title + " - " + quest.description);                  
                Debug.Log("Progress: " + quest.getProgress() + "%");
            }        
        );
	}
}
