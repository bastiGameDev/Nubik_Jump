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
        if (hungerText.gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;

            if (timer >= hungerDecreaseInterval)
            {
                currentHunger = Mathf.Max(0, currentHunger - 1);

                UpdateHungerText();

                timer = 0f;
            }
        }
    }

    void UpdateHungerText()
    {
        hungerText.text = $"{currentHunger}/100";
    }

}
