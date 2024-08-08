using UnityEngine;
using TMPro;

public class HungerSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro hungerText; 
    private int currentHunger = 100; 
    private float hungerDecreaseInterval = 1.55f; // Интервал уменьшения голодп
    private float timer = 0f; 

    void Update()
    {
        // Увеличиваем таймер каждый кадр
        timer += Time.deltaTime;

        // Если таймер достиг интервала уменьшения голода
        if (timer >= hungerDecreaseInterval)
        {
            // Уменьшаем голод на 1 единицу
            currentHunger = Mathf.Max(0, currentHunger - 1);

            // Обновляем текст
            UpdateHungerText();

            // Сбрасываем таймер
            timer = 0f;
        }
    }

    void UpdateHungerText()
    {
        // Обновляем текст с текущим значением голода
        hungerText.text = $"{currentHunger}/100";
    }
}
