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
    snsCostText,
    partJobCountText,
    partJobCostText;

    public Button 
    snsButton,
    workButton,
    employButton;

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
        snsFollowerText.text = "フォロワー : " + follower.ToString() + "人";
    }

    public void OnSNSCostChanged(int cost){
        snsCostText.text = "¥" + cost.ToString();
    }

    public void OnPartJobCountChanged(int count){
        partJobCountText.text = "バイト数 : " + count.ToString() + "人";
    }

    public void OnPartJobCostChanged(int cost){
        partJobCostText.text = "¥" + cost.ToString();
    }
}