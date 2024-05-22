using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTaker : MonoBehaviour
{

    QuestGiver qg;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver")
        {
            if(qg == null) 
            {           
                qg = other.gameObject.GetComponent<QuestGiver>();
                if(!qg.quest.isActive && !qg.quest.isComplete) {
                    qg.questPanel.SetActive(true);
                    qg.questInfos[0].text = qg.quest.title;
                    qg.questInfos[1].text = qg.quest.description;
                    qg.questInfos[2].text = "XP: " + qg.quest.xp + " | Gold : " + qg.quest.gold;
                }
                else
                {
                    if(qg.quest.isComplete)
                    {
                        qg.HideObjectAfterQuest();
                        print("Récompense = xp : " + qg .xp + " | gold : " + qg.po);
                        GetComponent<HeroCharacterCollisions>().ShowDialCanvasTxt(qg.questCompletedMsg);
                        GetComponent<HeroStats>().xp += qg.xp;
                        GetComponent<HeroStats>().po += qg.po;
                        qg.quest.isActive = false;
                        qg.po = 0;
                        qg.xp = 0;
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver")
        {
            qg.questPanel.SetActive(false);
            qg = null;
            GetComponent<HeroCharacterCollisions>().HideDialCanvas();
        }
    }

    public void TakeQuest()
    {
        qg.quest.isActive = true;
        qg.questPanel.SetActive(false);
    }

}
