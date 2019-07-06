using Communication;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameView : MonoBehaviour {
    [SerializeField] private Text
    moneyText,
    snsFollowerText,
    snsCostText,
    partJobCountText,
    partJobCostText,
    menuCountText,
    menuCostText,
    seatCountText,
    seatCostText,
    minMoneyPerTapText,
    maxMoneyPerTapText,
    totalCustomerCountText;

    public Button 
    snsButton,
    workButton,
    employButton,
    menuExtendButton,
    seatExtendButton;

    public void OnMoneyChanged (int money) {
        moneyText.text = "¥" + money.ToString ();
    }

    // public void OnPersonProductivityChanged (int person) {
    //     personProductivityText.text = person.ToString ();
    // }

    // public void OnSecondsProductivityChanged (float seconds) {
    //     secondsProductivityText.text = seconds.ToString ("f1");
    // }

    public void OnSNSFollowerChanged(int follower){
        snsFollowerText.text = "Follower : " + follower.ToString();
    }

    public void OnSNSCostChanged(int cost){
        snsCostText.text = StatusManager.Instance.snsLevel < GameInfo.MAX_SNS_LEVEL - 1 ? "¥" + cost.ToString() : "MAX";
    }

    public void OnPartJobCountChanged(int count){
        partJobCountText.text = "Staff : " + count.ToString() + " people";
    }

    public void OnPartJobCostChanged(int cost){
        partJobCostText.text = StatusManager.Instance.PartJobCount.Value < GameInfo.MAX_PART_TIME_LEVEL ? "¥" + cost.ToString() : "MAX";
    }

    public void OnMenuCountChanged(int count){
        menuCountText.text = "Menu Count : " + count.ToString();
    }

    public void OnMenuCostChanged(int cost){
        menuCostText.text = StatusManager.Instance.MenuCount.Value < GameInfo.MAX_MENU_COUNT ? "¥" + cost.ToString() : "MAX";
    }

    public void OnSeatCountChanged(int count){
        seatCountText.text = "Seat Count : " + count.ToString();
    }

    public void OnSeatCostChanged(int cost){
        seatCostText.text = StatusManager.Instance.seatLevel < GameInfo.MAX_SEAT_LEVEL - 1 ? "¥" + cost.ToString() : "MAX";
    }

    public void OnMinMoneyPerTapChanged(int money){
        minMoneyPerTapText.text = money.ToString() + " ~ ";
    }

    public void OnMaxMoneyPerTapChanged(int money){
        maxMoneyPerTapText.text = money.ToString() + "yen";
    }


    public void OnTotalCustomerChanged(int count){
        totalCustomerCountText.text = "COLLECTED CUSTOMER : " + count.ToString();
    }   
}