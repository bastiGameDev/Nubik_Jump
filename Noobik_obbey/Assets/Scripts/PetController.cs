using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform playerHead; // ������ �� ������ ���������
    public Transform petHolder; // ������ �� PetHolder
    public Transform cameraTransform; // ������ �� ������

    void Update()
    {
        if (playerHead != null && petHolder != null && cameraTransform != null)
        {
            // ������������� PetHolder ����� � ������� ���������
            //petHolder.position = playerHead.position + playerHead.up * 0.5f; // ������� ������ �� ������ ����������

            // ������� PetHolder ���, ����� �� ������� � ������� ������
            //petHolder.rotation = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);
        }
    }
}
