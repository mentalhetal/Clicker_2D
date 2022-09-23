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

    private int m_gold = 0;
    private int m_goldPerClick = 0;

    private void Awake()
    {
        m_gold = PlayerPrefs.GetInt("Gold");
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);
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

        upgradButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradButton.startGoldByUpgrade);
        upgradButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradButton)
    {
        string key = upgradButton.upgradeName;

        PlayerPrefs.SetInt(key + "_level", upgradButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradButton.currentCost);
    }
}