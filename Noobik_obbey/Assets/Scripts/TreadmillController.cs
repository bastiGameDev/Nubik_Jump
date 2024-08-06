using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillController : MonoBehaviour
{
    
    public CharacterController characterController;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource soundRun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 initialPosition = new Vector3(13.9700003f, 2.05699992f, -58.5299988f);
            player.transform.position = initialPosition;
            player.transform.rotation = Quaternion.identity;

            soundRun.Stop();

            player.GetComponent<movement>().enabled = false;
            characterController.enabled = false;

            animator.SetBool("isRunningOnTreadmill", true);

            StartCoroutine(RunTreadmill());
        }

    }

    private IEnumerator RunTreadmill()
    {
        yield return new WaitForSeconds(3f);

        animator.SetBool("isRunningOnTreadmill", false);

        Vector3 finalPosition = new Vector3(4.96000004f, 3.05699992f, -84.9800034f);
        player.transform.position = finalPosition;

        player.GetComponent<movement>().enabled = true;
        characterController.enabled = true;
    }
}
