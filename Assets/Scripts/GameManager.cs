using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private float spawnCustomerTimer;


    private void Update(){
        spawnCustomerTimer += Time.deltaTime;
        if(spawnCustomerTimer >= StatusManager.Instance.SecondsProductivity.Value){
            SpawnCustomer();
            spawnCustomerTimer = 0;
        }
    }

    private void SpawnCustomer(){
        
    }
}
