using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
    [HideInInspector] public int charge;

    private void Start () {
        SetCharge ();
        Invoke ("DestroyCustomer", StatusManager.Instance.StayTime.Value);
    }

    private void SetCharge () {
        charge = Random.Range (1000, 2000); //あとで変える
    }

    private void DestroyCustomer () {
        StatusManager.Instance.ChangeMoney (charge);
        Destroy (this.gameObject);
    }
}