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
        goldDisplayer.text = "∞ÒµÂ: " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "≈¨∏Ø Ω√ ∞ÒµÂ∑Æ : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisplyer.text = "√ ¥Á ∞ÒµÂ∑Æ : " + DataController.GetInstance().GetGoldPerSec();
    }
}
