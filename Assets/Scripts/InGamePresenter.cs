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
    }

    private void LoadGame () {
        StatusManager.Instance.SetMoney (GameInfo.DEFAULT_MONEY);
        StatusManager.Instance.SetPersonProductivity (GameInfo.DEFAULT_PERSON_PRODUCTIVITY);
        StatusManager.Instance.SetSecondsProductivity (GameInfo.DEFAULT_SECONDS_PRODUCTIVITY);
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
}