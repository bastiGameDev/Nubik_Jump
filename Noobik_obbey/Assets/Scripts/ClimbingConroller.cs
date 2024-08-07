using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource soundRun;
    public float climbHeight = 1.0f; // Высота подъема за одно нажатие
    [SerializeField] private float climbDuration = 10f; // Время подъема

    public CharacterController characterController;

    [SerializeField] private EconomyController economy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Vector3 initialPosition = new Vector3(3.96000004f, 2.05699992f, -44.7260017f);
            player.transform.position = initialPosition;
            player.transform.rotation = Quaternion.identity;

            soundRun.Stop();

            player.GetComponent<movement>().enabled = false;
            characterController.enabled = false; 

            animator.SetBool("isClimbing", true);

            StartCoroutine(Climb());
        }
    }

    private IEnumerator Climb()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = player.transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * economy.GetBanaceForce();

        while (elapsedTime < climbDuration)
        {
            float t = elapsedTime / climbDuration;
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = targetPosition;

        animator.SetBool("isClimbing", false);

        Vector3 finalPosition = new Vector3(4.96000004f, 3.05699992f, -84.9800034f);
        player.transform.position = finalPosition;

        player.GetComponent<movement>().enabled = true;
        characterController.enabled = true; 
    }
}
