using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedController : MonoBehaviour
{
    [SerializeField] private EconomyController economy;
    [SerializeField] private HungerSystem hunger;

    [SerializeField] private TextMeshProUGUI textInfo;

    private void OnTriggerEnter(Collider other)
    {
        textInfo.text = "Нажми Е чтобы покормить питомца";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hunger.currentHunger <= 90)
            {
                economy.MinusBanaceMoney(1);
                hunger.currentHunger = Mathf.Min(100, hunger.currentHunger + 20);
                hunger.UpdateHungerText(); 
            }
            else
            {
                textInfo.text = "Питомец уже сыт.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textInfo.text = "";
    }
}
