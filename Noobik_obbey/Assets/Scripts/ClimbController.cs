using UnityEngine;
using System.Collections;

public class ClimbController : MonoBehaviour
{
    public CharacterController characterController; // ��������� CharacterController
    public float climbHeight = 1.0f; // ������ ������� �� ���� �������
    public float climbDuration = 1.0f; // ����� �������

    private bool isClimbing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isClimbing) // ��������, ������� E ��� �������
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

        transform.position = targetPosition; // ��������, ��� �������� ������ ����
        isClimbing = false;
    }
}
