﻿using System.Collections;
using System.Collections.Generic;
using Communication;
using UniRx;
using UnityEngine;

public class InGamePresenter : MonoBehaviour {
    [SerializeField] private InGameView view;
    [SerializeField] private Command command;
    private void Start () {
        LoadGame ();
        Bind ();
        SetEvents ();
    }

    private void Update(){
        view.snsButton.interactable = StatusManager.Instance.Money.Value >= StatusManager.Instance.SnsCost.Value ? true : false;
    }

    private void LoadGame () {
        StatusManager.Instance.SetMoney (GameInfo.DEFAULT_MONEY);
        StatusManager.Instance.SetPersonProductivity (GameInfo.DEFAULT_PERSON_PRODUCTIVITY);
        StatusManager.Instance.SetSecondsProductivity (GameInfo.DEFAULT_SECONDS_PRODUCTIVITY);
        StatusManager.Instance.SetStayTime (GameInfo.DEFAULT_STAY_TIME);
        StatusManager.Instance.SetSnsFollowes(CommandInfo.SNS_FOLLOWER_ARRAY[0]);
    }

    private void Bind () {
        StatusManager.Instance.Money
            .Subscribe (view.OnMoneyChanged)
            .AddTo (gameObject);
        StatusManager.Instance.PersonProductivity
            .Subscribe (view.OnPersonProductivityChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SecondsProductivity
            .Subscribe (view.OnSecondsProductivityChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SnsFollowers
            .Subscribe(view.OnSNSFollowerChanged)
            .AddTo(gameObject);
        StatusManager.Instance.SnsCost
            .Subscribe(view.OnSNSCostChanged)
            .AddTo(gameObject);
    }

    private void SetEvents () {
        view.snsButton.onClick.AddListener (command.OnSNSButtonClicked);
        view.workButton.onClick.AddListener(command.OnWorkButtonClicked);
    }
}