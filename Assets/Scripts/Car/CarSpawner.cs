using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {
    [SerializeField] private float angle;
    private float spawnTimer;
    private float interval;

    private void Start(){
        interval = Random.Range (2f, 4f);
    }

    private void Update () {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= interval) {
            SpawnCar ();
            interval = Random.Range (5f, 10f);
            spawnTimer = 0;
        }
    }

    private void SpawnCar () {
        var num = Random.Range (0, 3);
        var car = Resources.Load ("Cars/Car" + num);
        Instantiate (car, transform.position, Quaternion.Euler (0, angle, 0));
    }
}