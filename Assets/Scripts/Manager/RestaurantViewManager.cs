﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestaurantViewManager : MonoBehaviour {
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject addTemplate;
    [SerializeField] private GameObject[] tables;
    [SerializeField] private Canvas titleCanvas;
    [SerializeField] private Canvas commandCanvas;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private Canvas clearCanvas;
    [SerializeField] private Text clearTimeText;
    [SerializeField] private Button goToGameButton;
    [SerializeField] private Button retryButton; 
    private Vector3 titleCameraPos = new Vector3 (7.8f, 5.9f, -3.9f);
    private Vector3 defaultCameraPos = new Vector3 (4.2f, 3.3f, 1.2f);
    private Vector3 secondCameraPos = new Vector3 (6f, 5f, 4.6f);

    private void Start () {
        SetTitle ();
        goToGameButton.onClick.AddListener (GoToGame);
        retryButton.onClick.AddListener(LoadNewGame);
    }

    public void ExtendRestaurant () {
        switch (StatusManager.Instance.seatLevel) {
            case 0:
            case 1:
            case 2:
            case 3:
            case 5:
            case 6:
            case 7:
                tables[StatusManager.Instance.seatLevel].SetActive (true);
                break;
            case 4:
                tables[StatusManager.Instance.seatLevel].SetActive (true);
                SetSecondCameraPos ();
                addTemplate.SetActive (true);
                break;
            default:
                break;
        }
    }

    private void SetTitle () {
        SetTitleCameraPos ();
        titleCanvas.gameObject.SetActive (true);
    }

    private void GoToGame () {
        GameManager.Instance.SetCurrentState (GameManager.GameState.GAME);
        titleCanvas.gameObject.SetActive (false);
        AudioManager.Instance.PlaySEWithVolume ("decision22", 0.9f);
        SetDefaultCameraPos ();
    }

    private void SetTitleCameraPos () {
        mainCam.transform.position = titleCameraPos;
    }

    private void SetDefaultCameraPos () {
        mainCam.transform.DOMove (
            defaultCameraPos,
            1f
        ).OnComplete (() => {
            commandCanvas.gameObject.SetActive (true);
            uiCanvas.gameObject.SetActive (true);
        });
    }

    private void SetSecondCameraPos () {
        mainCam.transform.DOMove (
            secondCameraPos,
            1f
        );
    }

    public void GameClear () {
        GameManager.Instance.SetCurrentState (GameManager.GameState.RESULT);
        commandCanvas.gameObject.SetActive (false);
        uiCanvas.gameObject.SetActive (false);
        clearTimeText.text = "Clear Time : " + ((int)GameManager.Instance.clearTime).ToString() + " SECONDS";
        DestroyCustomer();
        //AudioManager.Instance.StopBGM ();
        AudioManager.Instance.PlaySEWithVolume ("gameclear", 1f);
        clearCanvas.gameObject.SetActive (true);
        StartCoroutine(LoadRanking());
    }

    private void DestroyCustomer(){
        var customers = GameObject.FindGameObjectsWithTag("Customer");
        foreach(var u in customers){
            Destroy(u.gameObject);
        }
    }

    private IEnumerator LoadRanking(){
        yield return new WaitForSeconds(3f);
        int clearTime = (int)GameManager.Instance.clearTime;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (clearTime);
        yield return new WaitForSeconds(1f);
        retryButton.gameObject.SetActive(true);
    }

    private void LoadNewGame(){
        SceneManager.LoadScene("InGame");
    }
}