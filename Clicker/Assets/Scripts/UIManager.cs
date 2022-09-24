using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldDisplayer;
    [SerializeField]
    private TextMeshProUGUI goldPerClickDisplayer;
    [SerializeField]
    private TextMeshProUGUI goldPerSecDisplyer;

    private void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisplyer.text = "GOLD PER SEC: " + DataController.GetInstance().GetGoldPerSec();
    }
}
