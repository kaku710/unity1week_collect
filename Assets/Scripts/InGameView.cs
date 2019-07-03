using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameView : MonoBehaviour {
    [SerializeField] private Text
    moneyText,
    personProductivityText,
    secondsProductivityText;
    public Button snsButton;

    public void OnMoneyChanged (int money) {
        moneyText.text = "¥" + money.ToString ();
    }

    public void OnPersonProductivityChanged (int person) {
        personProductivityText.text = person.ToString ();
    }

    public void OnSecondsProductivityText (float seconds) {
        secondsProductivityText.text = seconds.ToString ("f1");
    }
}