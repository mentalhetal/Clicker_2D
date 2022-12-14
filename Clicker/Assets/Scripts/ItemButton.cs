using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public TextMeshProUGUI itemDisplayer;

    public string itemName;
    public int level;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerSec;
    public int startGoldPerSec = 1;

    public float upgradePow = 1.07f;
    public float costPow = 3.14f;

    [HideInInspector]
    public bool isPurchased = false;

    private void Start()
    {
        DataController.GetInstance().LoadItemButton(this);

        StartCoroutine("AddGoldLoop");

        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (DataController.GetInstance().GetGold() >= currentCost)
        {
            isPurchased = true;
            DataController.GetInstance().SubGold(currentCost);
            level++;

            UpdateItem();
            UpdateUI();

            DataController.GetInstance().SaveItemButton(this);
        }
    }

    private IEnumerator AddGoldLoop()
    {
        while(true)
        {
            if (isPurchased)
            {
                DataController.GetInstance().AddGold(goldPerSec);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = itemName + "\n레벨: " + level + "\n비용: " +
                             currentCost + "\n초당 골드량 추가: " + goldPerSec; //+ "\nIsPurchased: " + isPurchased;
    }
}
