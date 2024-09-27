using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanel; 

    private const string FirstTimeKey = "FirstTime";
    [SerializeField] private GameObject player;

    [SerializeField] GameObject[] tutorialFrames;


    void Start()
    {
        if (PlayerPrefs.GetInt(FirstTimeKey, 1) == 1)
        {
            player.GetComponent<movement>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            tutorialPanel.SetActive(true);

            PlayerPrefs.SetInt(FirstTimeKey, 0);
            PlayerPrefs.Save();
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }

    public void NextSlide(int currentSlide)
    {        
        tutorialFrames[currentSlide].gameObject.SetActive(false);
        tutorialFrames[currentSlide + 1].gameObject.SetActive(true);

    }

    public void FinishTutorial()
    {
        tutorialFrames[4].gameObject.SetActive(false);

        player.GetComponent<movement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
