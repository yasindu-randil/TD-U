using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 450;

    public static int Lives;
    public int startLive = 20;
    void Start()
    {
        Money = startMoney;
        Lives = startLive;
    }




}
