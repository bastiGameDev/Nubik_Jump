using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyEffectController : MonoBehaviour
{
    [SerializeField] private int indexEffect;

    [SerializeField] private string NameEffect;
    [SerializeField] private int priceEffect;
    [SerializeField] GameObject panelEffectShop;
    [SerializeField] TextMeshProUGUI textNameEffect;
    [SerializeField] TextMeshProUGUI textPrice;

    [SerializeField] private GameObject panelRejection;
    [SerializeField] private TextMeshProUGUI textRejection;

    [SerializeField] private GameObject alreadyBuyedEffect;

    public EconomyController economy;
    public EffectManager effectManager;

    private void OnTriggerStay(Collider other)
    {
        textNameEffect.text = NameEffect;
        textPrice.text = priceEffect.ToString();

        if (!effectManager.IsEffectPurchased(indexEffect))
        {
            panelEffectShop.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (economy.GetBanaceMoney() >= priceEffect)
                {
                    //����� ���� ����������� ���� ���������� �������

                    economy.MinusBanaceMoney(priceEffect);

                    effectManager.PurchaseEffect(indexEffect);
                    effectManager.ActivateEffect(indexEffect);
                }
                else
                {
                    panelRejection.SetActive(true);
                    textRejection.text = "������������ �����";
                }
            }
        }
        else
        {
            alreadyBuyedEffect.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Y))
            {
                effectManager.ActivateEffect(indexEffect);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        alreadyBuyedEffect.SetActive(false);
        panelRejection.SetActive(false);
        panelEffectShop.SetActive(false);
    }
}
