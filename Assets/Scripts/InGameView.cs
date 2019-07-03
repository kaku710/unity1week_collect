using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameView : MonoBehaviour {
    [SerializeField] private Text
    moneyText,
    personProductivityText,
    secondsProductivityText,
    snsFollowerText,
    snsCostText;
    public Button snsButton;

    public void OnMoneyChanged (int money) {
        moneyText.text = "¥" + money.ToString ();
    }

    public void OnPersonProductivityChanged (int person) {
        personProductivityText.text = person.ToString ();
    }

    public void OnSecondsProductivityChanged (float seconds) {
        secondsProductivityText.text = seconds.ToString ("f1");
    }

    public void OnSNSFollowerChanged(int follower){
        snsFollowerText.text = follower.ToString() + "人";
    }

    public void OnSNSCostChanged(int cost){
        snsCostText.text = "¥" + cost.ToString();
    }
}