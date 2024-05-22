using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroCharacterCollisions : MonoBehaviour
{
    public GameObject dialWorldSpace;

    public TMP_Text dialTxt;

    Collider2D otherObj;

    public GameObject dialCanvas;

    public Text dialCanvasTxt;

    public QuestGiver[] quests;

    public GameObject camFight;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign")
        {
            otherObj = other;
            //dialWorldSpace.SetActive(true);
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            //dialTxt.SetText(sb.signText);
            sb.ui.SetActive(true);
        }
        if(other.gameObject.tag == "flower")
        {
            otherObj = other;
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if(other.gameObject.tag == "exit")
        {
            string point = other.gameObject.GetComponent<ExitBehaviour>().teleportPoint;
            PlayerPrefs.SetString("Point", point);
            Application.LoadLevel(other.gameObject.name);
        }
        if (other.gameObject.tag == "mob")
        {
            print("Combat");
            camFight.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign")
        {
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(false);
            otherObj = null;
            Invoke("HideDialPanel", 1);
        }
        if(other.gameObject.tag == "flower")
        {
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            otherObj = null;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "garde")
        {
            ShowDialCanvasTxt(other.gameObject.GetComponent<PnjSimpleDial>().simpleDial);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "garde")
        {
            HideDialCanvas();
        }
    }

    public void HideDialPanel()
    {
        dialWorldSpace.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && otherObj != null)
        {
            if(otherObj.gameObject.tag == "sign")
            {
                ShowDial();
            }
            if(otherObj.gameObject.tag == "flower")
            {
                if(quests[0].quest.isActive) 
                {
                    ShowDialCanvasTxt("Count : " + quests[0].quest.count);
                    quests[0].quest.IncrementCount();
                }
                otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                otherObj.gameObject.SetActive(false);
                otherObj = null;

            }
        }
    }

    public void ShowDial()
    {
        SignBehaviour sb = otherObj.gameObject.GetComponent<SignBehaviour>();
        sb.ui.SetActive(false);
        dialWorldSpace.SetActive(true);
        dialTxt.SetText(sb.signText);
    }

    public void ShowDialCanvasTxt(string msg)
    {
        dialCanvas.SetActive(true);
        dialCanvasTxt.text = msg;
    }

    public void HideDialCanvas()
    {
        dialCanvas.SetActive(false);
    }

}
