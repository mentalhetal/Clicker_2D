using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI upgradeDisplayer;

    public string upgradeName;

    [HideInInspector]
    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;

    [HideInInspector]
    public int currentCost = 1;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int level = 1;

    public float upgradePow = 1.07f;

    public float costPow = 3.14f;

    private void Start()
    {
        DataController.GetInstance().LoadUpgaradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (DataController.GetInstance().GetGold() >= currentCost )
        {
            DataController.GetInstance().SubGold(currentCost);
            level++;
            DataController.GetInstance().AddGoldPerClick(goldByUpgrade);

            UpdateUpgrade();
            UpdateUI();
            DataController.GetInstance().SaveUpgradeButton(this);
        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = upgradeName + "\nLevel: " + level + "\nCost: " + currentCost +
                                "\nNext GoldPerClick: " + goldByUpgrade;
    }
}
