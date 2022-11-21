using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 450;

    public static int Lives;
    public int startLive = 100;
    void Start()
    {
        Money = startMoney;
        Lives = 100;
    }




}
