using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanel; 

    private const string FirstTimeKey = "FirstTime";

    void Start()
    {
        if (PlayerPrefs.GetInt(FirstTimeKey, 1) == 1)
        {
            tutorialPanel.SetActive(true);

            PlayerPrefs.SetInt(FirstTimeKey, 0);
            PlayerPrefs.Save();
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }
}
