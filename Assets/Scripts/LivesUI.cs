
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using TMPro;
public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.Lives+" Lives";
    }
}
