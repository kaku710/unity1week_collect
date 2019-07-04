using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour {
    [HideInInspector] public int customerCount;
    [SerializeField] private Transform[] seatTransforms;
    [SerializeField] private Customer customer;
    [HideInInspector] public bool[] isEating;
    private float spawnTimer;

    private void Start () {
        customerCount = 0;
        isEating = new bool[32];
        for(int i = 0; i < isEating.Length; i++){
            isEating[i] = false;
        }
    }

    private void Update(){
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= StatusManager.Instance.SecondsProductivity.Value && customerCount < StatusManager.Instance.SeatCount.Value){
            SpawnCustomer();
            spawnTimer = 0;
        }
    }

    private void SpawnCustomer(){
        int seatNumber = GetSeatNumber();
        float angleY = (seatNumber % 4) * 90;
        var cus = Instantiate (customer, seatTransforms[seatNumber].position, Quaternion.Euler (0, angleY, 0));
        cus.customerSpawner = this;
        cus.seatID = seatNumber;
        customerCount++;
        isEating[seatNumber] = true;
    }

    private int GetSeatNumber(){
        int seatNumber = 0;
        while(true){
            seatNumber = Random.Range (0, StatusManager.Instance.SeatCount.Value);
            if(isEating[seatNumber] == false) break;
        }
        return seatNumber;
    }
}