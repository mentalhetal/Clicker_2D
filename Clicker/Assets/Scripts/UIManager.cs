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

    private void Update()
    {
        goldDisplayer.text = "GOLD: " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "GOLD PER CLICK: " + DataController.GetInstance().GetGoldPerClick();
    }
}
