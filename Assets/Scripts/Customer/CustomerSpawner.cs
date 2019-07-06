using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Communication;

public class CustomerSpawner : MonoBehaviour {
    [HideInInspector] public int customerCount;
    [SerializeField] private Transform[] seatTransforms;
    private GameObject customer;
    [HideInInspector] public bool[] isEating;
    private float spawnTimer;
    private float interval;

    private void Start () {
        customerCount = 0;
        isEating = new bool[32];
        interval = Random.Range(
            GameInfo.DEFAULT_SECONDS_PRODUCTIVITY * 0.9f,
            GameInfo.DEFAULT_SECONDS_PRODUCTIVITY * 1.1f
        );
        for (int i = 0; i < isEating.Length; i++) {
            isEating[i] = false;
        }
    }

    private void Update () {
        if (GameManager.Instance.currentGameState != GameManager.GameState.GAME) return;
        spawnTimer += Time.deltaTime;
        if ((spawnTimer >= interval)) {
            int spawnCount = Random.Range (1, StatusManager.Instance.PersonProductivity.Value + 1);
            for (int i = 0; i < spawnCount; i++) {
                if (customerCount < StatusManager.Instance.SeatCount.Value) SpawnCustomer ();
            }
            spawnTimer = 0;
            interval = Random.Range(
                StatusManager.Instance.SecondsProductivity.Value * 0.9f,
                StatusManager.Instance.SecondsProductivity.Value * 1.1f
            );
        }
    }

    private void SpawnCustomer () {
        int seatNumber = GetSeatNumber ();
        float angleY = (seatNumber % 4) * 90;
        int id = Random.Range(0,36);
        var obj = (GameObject)Resources.Load("Customer/Customer" + id);
        var cus = Instantiate (obj, seatTransforms[seatNumber].position, Quaternion.Euler (0, angleY, 0));
        cus.GetComponent<Customer>().customerSpawner = this;
        cus.GetComponent<Customer>().seatID = seatNumber;
        customerCount++;
        isEating[seatNumber] = true;
    }

    private int GetSeatNumber () {
        int seatNumber = 0;
        while (true) {
            seatNumber = Random.Range (0, StatusManager.Instance.SeatCount.Value);
            if (isEating[seatNumber] == false) break;
        }
        return seatNumber;
    }
}