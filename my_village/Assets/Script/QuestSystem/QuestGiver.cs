using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject questPanel;
    public Text[] questInfos;
    public string questCompletedMsg;
    public int xp = 50;
    public int po = 500;
    public GameObject[] toHideAfterQuestCompleted;

    public void HideObjectAfterQuest()
    {
        foreach (GameObject go in toHideAfterQuestCompleted)
        {
            go.SetActive(false);
        }
    }

}