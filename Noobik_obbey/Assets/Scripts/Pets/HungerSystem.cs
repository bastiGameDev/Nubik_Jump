using UnityEngine;
using TMPro;

public class HungerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro hungerText;
    [SerializeField] private EconomyController economy; // Добавьте ссылку на ваш экономический скрипт
    private int currentHunger = 100;
    private float hungerDecreaseInterval = 1.55f; // Интервал уменьшения голода
    private float timer = 0f;

    private const string HungerKey = "Hunger";

    void Start()
    {
        // Загружаем значение голода из PlayerPrefs при запуске игры
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
                    // Уменьшаем голод на 1 единицу
                    currentHunger = Mathf.Max(0, currentHunger - 1);
                    UpdateHungerText();
                }
                else
                {
                    // Если голод достиг 0, проверяем текущее значение энергии
                    int currentEnergy = economy.GetBanaceForce();
                    if (currentEnergy > 0)
                    {
                        // Если энергия больше 0, вызываем метод для уменьшения энергии игрока
                        economy.MinusBanaceForce(1);
                        // Увеличиваем голод питомца на 1 единицу
                        currentHunger = Mathf.Min(100, currentHunger + 1);
                        UpdateHungerText();
                    }
                }

                // Сбрасываем таймер
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
        // Сохраняем значение голода в PlayerPrefs перед выходом из игры
        SaveHunger();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            // Сохраняем значение голода в PlayerPrefs при потере фокуса
            SaveHunger();
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Сохраняем значение голода в PlayerPrefs при приостановке приложения
            SaveHunger();
        }
    }

    private void SaveHunger()
    {
        PlayerPrefs.SetInt(HungerKey, currentHunger);
        PlayerPrefs.Save();
    }
}
