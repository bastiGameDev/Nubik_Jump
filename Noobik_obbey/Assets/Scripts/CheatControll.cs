using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatControll : MonoBehaviour
{
    public EconomyController economyController;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            economyController.PlusBanaceMoney(100);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            economyController.PlusBanaceForce(100);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            economyController.PlusBanaceForce(-10);
        }
    }
}
