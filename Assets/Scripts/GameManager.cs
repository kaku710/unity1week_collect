using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    [SerializeField] private Customer customer;
    private float spawnCustomerTimer;
    [SerializeField] private Transform customerParentTransform;

    private void Update () {
        spawnCustomerTimer += Time.deltaTime;
        if (spawnCustomerTimer >= StatusManager.Instance.SecondsProductivity.Value) {
            SpawnCustomer ();
            spawnCustomerTimer = 0;
        }
    }

    private void SpawnCustomer () {
        Instantiate (customer, customerParentTransform);
    }
}