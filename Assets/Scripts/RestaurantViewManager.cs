using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RestaurantViewManager : MonoBehaviour {
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject addTemplate;
    [SerializeField] private GameObject[] tables;
    private Vector3 defaultCameraPos = new Vector3 (4.2f, 3.3f, 1.2f);
    private Vector3 secondCameraPos = new Vector3 (6f, 5f, 4.6f);

    private void Start () {
        mainCam.transform.position = defaultCameraPos;
    }

    public void ExtendRestaurant () {
        switch(StatusManager.Instance.seatLevel){
            case 0:
            case 1:
            case 2:
            case 3:
            case 5:
            case 6:
            case 7:
                tables[StatusManager.Instance.seatLevel].SetActive(true);
                break;
            case 4:
                tables[StatusManager.Instance.seatLevel].SetActive(true);
                SetSecondCameraPos ();
                addTemplate.SetActive (true);
                break;
            default:
                break;
        }
    }

    private void SetSecondCameraPos () {
        mainCam.transform.DOMove (
            secondCameraPos,
            1f
        );
    }
}