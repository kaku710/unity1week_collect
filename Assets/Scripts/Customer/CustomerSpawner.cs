using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] private Transform[] seatTransforms;
    [SerializeField] private GameObject customer;

    private void Start () {
        int rndNumber = Random.Range (0, 4);
        float angleY = (rndNumber % 4) * 90;
        Instantiate (customer, seatTransforms[rndNumber].position, Quaternion.Euler (0, angleY, 0));
    }
}