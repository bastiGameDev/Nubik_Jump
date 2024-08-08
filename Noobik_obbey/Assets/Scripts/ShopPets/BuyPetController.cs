using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPetController : MonoBehaviour
{
    [SerializeField] private int indexPet;

    public PetManager petManager;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Сработал триггер");

        if (Input.GetKeyDown(KeyCode.E))
        {
            petManager.ActivatePet(indexPet);

            
        }
    }
}
