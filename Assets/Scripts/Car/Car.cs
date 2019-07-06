using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private void Update()
    {
        transform.position -= transform.forward * 3f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "EndLine"){
            Destroy(this.gameObject);
        }
    }
}
