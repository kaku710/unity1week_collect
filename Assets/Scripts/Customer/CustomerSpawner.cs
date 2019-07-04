using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour {
    [SerializeField] private Transform[] seatTransforms;
    [SerializeField] private GameObject customer;
    private float spawnTimer;

    private void Start () {
        
    }

    private void Update(){
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= StatusManager.Instance.SecondsProductivity.Value){
            SpawnCustomer();
            spawnTimer = 0;
        }
    }

    private void SpawnCustomer(){
        int rndNumber = Random.Range (0, StatusManager.Instance.SeatCount.Value);
        float angleY = (rndNumber % 4) * 90;
        Instantiate (customer, seatTransforms[rndNumber].position, Quaternion.Euler (0, angleY, 0));
    }
}