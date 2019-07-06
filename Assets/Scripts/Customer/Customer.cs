using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    [HideInInspector] public int charge;
    [HideInInspector] public CustomerSpawner customerSpawner;
    [HideInInspector] public int seatID;

    private void Start () {
        SetCharge ();
        float rnd = Random.Range(0.9f,1.1f);
        Invoke ("DestroyCustomer", StatusManager.Instance.StayTime.Value * rnd);
    }

    private void SetCharge () {
        charge = Random.Range (StatusManager.Instance.minCharge, StatusManager.Instance.maxCharge + 1); //あとで変える
    }

    private void DestroyCustomer () {
        StatusManager.Instance.ChangeMoney (charge);
        customerSpawner.isEating[seatID] = false;
        customerSpawner.customerCount--;
        Destroy (this.gameObject);
    }
}