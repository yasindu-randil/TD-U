using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$"+PlayerStats.Money.ToString();
    }
}
