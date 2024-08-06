using UnityEngine;
using System.Collections;

public class ClimbController : MonoBehaviour
{
    public CharacterController characterController; // Компонент CharacterController
    public float climbHeight = 1.0f; // Высота подъема за одно нажатие
    public float climbDuration = 1.0f; // Время подъема

    private bool isClimbing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isClimbing) // Например, клавиша E для подъема
        {
            StartCoroutine(Climb());
        }
    }

    private IEnumerator Climb()
    {
        isClimbing = true;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * climbHeight;

        while (elapsedTime < climbDuration)
        {
            float t = elapsedTime / climbDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Убедимся, что достигли точной цели
        isClimbing = false;
    }
}
