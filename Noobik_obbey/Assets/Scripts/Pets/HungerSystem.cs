using UnityEngine;
using TMPro;

public class HungerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro hungerText;
    [SerializeField] private EconomyController economy; // �������� ������ �� ��� ������������� ������
    private int currentHunger = 100;
    private float hungerDecreaseInterval = 1.55f; // �������� ���������� ������
    private float timer = 0f;

    private const string HungerKey = "Hunger";

    void Start()
    {
        // ��������� �������� ������ �� PlayerPrefs ��� ������� ����
        currentHunger = PlayerPrefs.GetInt(HungerKey, 100);
        UpdateHungerText();
    }

    void Update()
    {
        if (hungerText.gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;

            if (timer >= hungerDecreaseInterval)
            {
                if (currentHunger > 0)
                {
                    // ��������� ����� �� 1 �������
                    currentHunger = Mathf.Max(0, currentHunger - 1);
                    UpdateHungerText();
                }
                else
                {
                    // ���� ����� ������ 0, ��������� ������� �������� �������
                    int currentEnergy = economy.GetBanaceForce();
                    if (currentEnergy > 0)
                    {
                        // ���� ������� ������ 0, �������� ����� ��� ���������� ������� ������
                        economy.MinusBanaceForce(1);
                        // ����������� ����� ������� �� 1 �������
                        currentHunger = Mathf.Min(100, currentHunger + 1);
                        UpdateHungerText();
                    }
                }

                // ���������� ������
                timer = 0f;
            }
        }
    }

    void UpdateHungerText()
    {
        hungerText.text = $"{currentHunger}/100";
    }

    void OnApplicationQuit()
    {
        // ��������� �������� ������ � PlayerPrefs ����� ������� �� ����
        SaveHunger();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            // ��������� �������� ������ � PlayerPrefs ��� ������ ������
            SaveHunger();
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // ��������� �������� ������ � PlayerPrefs ��� ������������ ����������
            SaveHunger();
        }
    }

    private void SaveHunger()
    {
        PlayerPrefs.SetInt(HungerKey, currentHunger);
        PlayerPrefs.Save();
    }
}
