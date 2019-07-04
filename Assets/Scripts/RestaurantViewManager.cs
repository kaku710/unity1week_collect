using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaurantViewManager : MonoBehaviour {
    [SerializeField] private GameObject mainCam;
    private Vector3 defaultCameraPos = new Vector3 (4.2f, 3.3f, 1.2f);
    private Vector3 secondCameraPos = new Vector3 (6f, 5f, 4.6f);
    private void Start () {
        mainCam.transform.position = defaultCameraPos;
    }
}