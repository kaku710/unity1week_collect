using System.Collections;
using System.Collections.Generic;
using Communication;
using UniRx;
using UnityEngine;

public class InGamePresenter : MonoBehaviour {
    [SerializeField] private InGameView view;
    private void Start () {
        LoadGame ();
        Bind ();
        SetEvents ();
    }

    private void LoadGame () {
        StatusManager.Instance.SetMoney (GameInfo.DEFAULT_MONEY);
        StatusManager.Instance.SetPersonProductivity (GameInfo.DEFAULT_PERSON_PRODUCTIVITY);
        StatusManager.Instance.SetSecondsProductivity (GameInfo.DEFAULT_SECONDS_PRODUCTIVITY);
        StatusManager.Instance.SetStayTime (GameInfo.DEFAULT_STAY_TIME);
    }

    private void Bind () {
        StatusManager.Instance.Money
            .Subscribe (view.OnMoneyChanged)
            .AddTo (gameObject);
        StatusManager.Instance.PersonProductivity
            .Subscribe (view.OnPersonProductivityChanged)
            .AddTo (gameObject);
        StatusManager.Instance.SecondsProductivity
            .Subscribe (view.OnSecondsProductivityText)
            .AddTo (gameObject);
    }

    private void SetEvents () {
        view.snsButton.onClick.AddListener (OnSNSButtonClicked);
    }

    private void OnSNSButtonClicked () {
        if (StatusManager.Instance.SecondsProductivity.Value > 1.002f) {
            float downRate = 0.2f;
            StatusManager.Instance.DownSecondsProductivity (downRate);
            if (StatusManager.Instance.SecondsProductivity.Value <= 1f) StatusManager.Instance.SetSecondsProductivity (1f);
        }
        else {
            StatusManager.Instance.ChangePersonProductivity(1);
        }
    }
}