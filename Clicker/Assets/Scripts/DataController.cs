using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;
    public static DataController GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if (instance == null)
            {
                GameObject container = new GameObject("DataController");

                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }

    private ItemButton[] itemButtons;

    private int m_gold = 0;
    private int m_goldPerClick = 0;

    private void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    public void SetGold(int newGold)
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
    }

    public void AddGold(int newGold)
    {
        m_gold += newGold;
        SetGold(m_gold);
    }

    public void SubGold(int newGold)
    {
        m_gold -= newGold;
        SetGold(m_gold);
    }

    public int GetGold()
    {
        return m_gold;
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgaradeButton(UpgradeButton upgradButton)
    {
        string key = upgradButton.upgradeName;

        upgradButton.level          = PlayerPrefs.GetInt(key + "_level", 1);
        upgradButton.goldByUpgrade  = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradButton.startGoldByUpgrade);
        upgradButton.currentCost    = PlayerPrefs.GetInt(key + "_cost", upgradButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradButton)
    {
        string key = upgradButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradButton.currentCost);
    }

    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        itemButton.level        = PlayerPrefs.GetInt(key + "_level");
        itemButton.goldPerSec   = PlayerPrefs.GetInt(key + "_goldPerSec");
        itemButton.currentCost  = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);

        if (PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);

        if (itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for (int i = 0; i < itemButtons.Length; i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }

        return goldPerSec;
    }
}
