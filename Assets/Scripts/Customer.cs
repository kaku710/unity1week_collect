﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    [HideInInspector] public int charge;

    private void Start () {
        SetCharge ();
        Invoke ("DestroyCustomer", StatusManager.Instance.StayTime.Value);
    }

    private void SetCharge () {
        charge = Random.Range (StatusManager.Instance.minCharge, StatusManager.Instance.maxCharge + 1); //あとで変える
    }

    private void DestroyCustomer () {
        StatusManager.Instance.ChangeMoney (charge);
        Destroy (this.gameObject);
    }
}