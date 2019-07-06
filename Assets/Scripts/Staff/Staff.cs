using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [HideInInspector] public int ID;
    [SerializeField] private GameObject cap;
    [SerializeField] private GameObject body;

    private void Start(){
        cap.SetActive(false);
        body.SetActive(false);
    }
    private void Update()
    {
        if(StatusManager.Instance.seatLevel < 4){
            if(ID > 7){
                cap.SetActive(false);
                body.SetActive(false);
            }else{
                cap.SetActive(true);
                body.SetActive(true);
            }
        }else{
            cap.SetActive(true);
            body.SetActive(true);
        }
    }
}
