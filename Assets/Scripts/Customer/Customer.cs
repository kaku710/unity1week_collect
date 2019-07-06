using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour {
    [HideInInspector] public int charge;
    [HideInInspector] public CustomerSpawner customerSpawner;
    [HideInInspector] public int seatID;
    private float localStayTime;
    private Sequence customerAnim;

    private void Start () {
        SetCharge ();
        float rnd = Random.Range (0.9f, 1.1f);
        localStayTime = StatusManager.Instance.StayTime.Value * rnd;
        Invoke ("DestroyCustomer", localStayTime);
        SetSequence ();
        customerAnim.Play ();
    }

    private void SetCharge () {
        charge = Random.Range (StatusManager.Instance.minCharge, StatusManager.Instance.maxCharge + 1); //あとで変える
    }

    private void SetSequence () {
        customerAnim = DOTween.Sequence ();
        for (int i = 0; i < 5; i++) {
            customerAnim.Append (transform.DOMoveY (
                transform.position.y + 0.05f,
                localStayTime / 11f
            ));
            customerAnim.Append (transform.DOMoveY (
                transform.position.y,
                localStayTime / 11f
            ));
        }
        customerAnim.Append (transform.DOScale (
            Vector3.zero,
            localStayTime / 11f
        ));
    }

    private void DestroyCustomer () {
        StatusManager.Instance.ChangeMoney (charge);
        customerSpawner.isEating[seatID] = false;
        customerSpawner.customerCount--;
        Destroy (this.gameObject);
    }
}