using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject[] pets; // Массив объектов питомцев
    private int activePetIndex = -1; // Индекс активного питомца
    private bool[] purchasedPets; // Массив для отслеживания купленных питомцев

    private const string PETS_PURCHASED_KEY = "PetsPurchased";
    private const string ACTIVE_PET_INDEX_KEY = "ActivePetIndex";

    void Start()
    {
        // Инициализация массива купленных питомцев
        purchasedPets = new bool[pets.Length];

        // Загрузка данных о купленных питомцах
        LoadPurchasedPets();

        // Загрузка данных об активном питомце
        LoadActivePet();

        // Активация питомца, если он был сохранен
        if (activePetIndex >= 0 && activePetIndex < pets.Length)
        {
            ActivatePet(activePetIndex);
        }
    }

    void LoadPurchasedPets()
    {
        string purchasedPetsData = PlayerPrefs.GetString(PETS_PURCHASED_KEY, "");
        if (!string.IsNullOrEmpty(purchasedPetsData))
        {
            string[] purchasedPetsArray = purchasedPetsData.Split(',');
            for (int i = 0; i < purchasedPetsArray.Length; i++)
            {
                purchasedPets[i] = bool.Parse(purchasedPetsArray[i]);
            }
        }
    }

    void LoadActivePet()
    {
        activePetIndex = PlayerPrefs.GetInt(ACTIVE_PET_INDEX_KEY, -1);
    }

    public void PurchasePet(int index)
    {
        if (index >= 0 && index < pets.Length)
        {
            purchasedPets[index] = true;
            SavePurchasedPets();
        }
    }

    public void ActivatePet(int index)
    {
        if (index >= 0 && index < pets.Length && purchasedPets[index])
        {
            // Деактивируем текущего активного питомца
            if (activePetIndex >= 0 && activePetIndex < pets.Length)
            {
                pets[activePetIndex].SetActive(false);
            }

            // Активируем нового питомца
            pets[index].SetActive(true);
            activePetIndex = index;
            SaveActivePet();
        }
    }

    void SavePurchasedPets()
    {
        string purchasedPetsData = string.Join(",", purchasedPets);
        PlayerPrefs.SetString(PETS_PURCHASED_KEY, purchasedPetsData);
    }

    void SaveActivePet()
    {
        PlayerPrefs.SetInt(ACTIVE_PET_INDEX_KEY, activePetIndex);
    }
}
