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
        goldDisplayer.text = "���: " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "Ŭ�� �� ��差 : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisplyer.text = "�ʴ� ��差 : " + DataController.GetInstance().GetGoldPerSec();
    }
}
