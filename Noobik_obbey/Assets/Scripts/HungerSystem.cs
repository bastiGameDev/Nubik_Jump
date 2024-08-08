using UnityEngine;
using TMPro;

public class HungerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro hungerText; 
    private int currentHunger = 100; 
    private float hungerDecreaseInterval = 1.55f; // �������� ���������� ������
    private float timer = 0f; 

    void Update()
    {
        // ����������� ������ ������ ����
        timer += Time.deltaTime;

        // ���� ������ ������ ��������� ���������� ������
        if (timer >= hungerDecreaseInterval)
        {
            // ��������� ����� �� 1 �������
            currentHunger = Mathf.Max(0, currentHunger - 1);

            // ��������� �����
            UpdateHungerText();

            // ���������� ������
            timer = 0f;
        }
    }

    void UpdateHungerText()
    {
        // ��������� ����� � ������� ��������� ������
        hungerText.text = $"{currentHunger}/100";
    }
}
