using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int FanSum;
    public int Haters;
    public int Likers;
    public float FanTime = 0.5f;
    public float UnsubTime;
    public float MaxFanTime = 0.5f;
    public float MaxUnsubTime;
    public float MultiplyGoal = 5;
    public int Subscription_Amplifier = 1;

    private void Update()
    {
        FanSum = DataManager.FanSum;
        Haters = DataManager.Haters;
        Likers = DataManager.Likers;
        FanTime = DataManager.FanTime;
        UnsubTime = DataManager.UnsubTime;
        MaxFanTime = DataManager.MaxFanTime;
        MaxUnsubTime = DataManager.MaxUnsubTime;
        MultiplyGoal = DataManager.MultiplyGoal;
        Subscription_Amplifier = DataManager.Subscription_Amplifier;
    }
}
