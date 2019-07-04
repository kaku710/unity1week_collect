using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private Transform seatTransform;
    [SerializeField] private GameObject customer;

    private void Start(){
        Instantiate(customer,seatTransform.position,Quaternion.identity);
    }
}
