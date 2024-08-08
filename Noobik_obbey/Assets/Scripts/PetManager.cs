using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject[] pets; // ������ �������� ��������
    private int activePetIndex = -1; // ������ ��������� �������
    private bool[] purchasedPets; // ������ ��� ������������ ��������� ��������

    private const string PETS_PURCHASED_KEY = "PetsPurchased";
    private const string ACTIVE_PET_INDEX_KEY = "ActivePetIndex";

    void Start()
    {
        // ������������� ������� ��������� ��������
        purchasedPets = new bool[pets.Length];

        // �������� ������ � ��������� ��������
        LoadPurchasedPets();

        // �������� ������ �� �������� �������
        LoadActivePet();

        // ��������� �������, ���� �� ��� ��������
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
            // ������������ �������� ��������� �������
            if (activePetIndex >= 0 && activePetIndex < pets.Length)
            {
                pets[activePetIndex].SetActive(false);
            }

            // ���������� ������ �������
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
