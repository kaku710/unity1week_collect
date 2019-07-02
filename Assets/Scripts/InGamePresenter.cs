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
        GameManager.Instance.SetMoney (GameInfo.DEFAULT_MONEY);
        GameManager.Instance.SetPersonProductivity (GameInfo.DEFAULT_PERSON_PRODUCTIVITY);
        GameManager.Instance.SetSecondsProductivity (GameInfo.DEFAULT_SECONDS_PRODUCTIVITY);
    }

    private void Bind () {
        GameManager.Instance.Money
            .Subscribe (view.OnMoneyChanged)
            .AddTo (gameObject);
        GameManager.Instance.PersonProductivity
            .Subscribe (view.OnPersonProductivityChanged)
            .AddTo (gameObject);
        GameManager.Instance.SecondsProductivity
            .Subscribe (view.OnSecondsProductivityText)
            .AddTo (gameObject);
    }
}